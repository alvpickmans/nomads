namespace Nomads;

public static partial class ResultTests
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
}