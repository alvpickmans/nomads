namespace Nomads;

public static partial class ResultTests
{
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