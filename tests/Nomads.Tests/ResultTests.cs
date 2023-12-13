using FluentAssertions;

namespace Nomads;

public class ResultTests
{
    public class Constructors
    {
        [Fact]
        public void with_Ok_constructor()
        {
            Result<string, Exception> result = Ok("Success!");
            result
                .Reduce(ok => ok, err => err.Message)
                .Should().Be("Success!");
        }
        
        [Fact]
        public void with_implicit_Ok()
        {
            Result<string, Exception> result = "Success!";
            result
                .Reduce(ok => ok, err => err.Message)
                .Should().Be("Success!");
        }
    
        [Fact]
        public void with_Error_constructor()
        {
            Result<string, Exception> result = Error(new Exception("The operation failed"));
            result
                .Reduce(ok => ok, err => err.Message)
                .Should().Be("The operation failed");
        }
        
        [Fact]
        public void with_implicit_Error()
        {
            Result<string, Exception> result = new Exception("The operation failed");
            result
                .Reduce(ok => ok, err => err.Message)
                .Should().Be("The operation failed");
        }
    }

    public class Equality
    {
    
        [Fact]
        public void with_Ok_instance()
        {
            Result<string, Exception> result = "All good folks.";
            string output = Ok("All good folks.") == result
                ? "ok"
                : "err";

            output.Should().Be("ok");
        }
        
    
        [Fact]
        public void with_Error_instance()
        {
            Result<string, int> result = -1;
            string output = Error(-1) == result
                ? "err"
                : "ok";

            output.Should().Be("err");
        }
    }

    public class Reduce
    {
        [Fact]
        public void from_value_type_result() =>
            Ok<int, Exception>(42)
                .Reduce(
                    ok => ok.Should().Be(42),
                    _ => throw new Exception("Unexpected error branch"));

        [Fact]
        public void from_reference_type_result() =>
            Error<string, Exception>(new Exception("oh no!"))
                .Reduce(
                    _ => throw new Exception("Unexpected error branch"),
                    err => err.Message.Should().Be("oh no!")
                );
    }

    public class Map
    {
        [Fact]
        public void ok_result_with_value_type_delegate() =>
            TryParse("3.14")
                .Map(x => x * 2)
                .Reduce(
                    amount => amount.Should().BeApproximately(6.28, precision: 2),
                    err => throw new Exception(err)
                );
        
        [Fact]
        public void error_result_with_value_type_delegate() =>
            TryParse("3 quarters")
                .Map(x => x * 2)
                .Reduce(
                    _ => throw new Exception("Unexpected ok branch"),
                    err => err.Should().Be("Input '3 quarters' is not a number")
                );
            
        private static Result<double, string> TryParse(string input) =>
            double.TryParse(input, out double value)
                ? value
                : $"Input '{input}' is not a number";
    }
}