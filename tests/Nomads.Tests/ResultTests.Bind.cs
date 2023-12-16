namespace Nomads;

public static partial class ResultTests
{
    public class Bind
    {
        [Theory]
        [InlineData("3.14", 3.14)]
        [InlineData("not a number", -1)]
        public void option_bound_to_delegate(string input, int expected) =>
            Ok<string, string>(input)
                .Bind(TryParse)
                .Reduce(ok => ok, _ => -1)
                .Should().BeApproximately(expected, precision: 2);

        [Theory]
        [InlineData("3.14", 3.14)]
        [InlineData("not a number", -1)]
        public void delegate_bound_to_option(string input, int expected) =>
            Result.Bind((string x) => TryParse(x))
                .Invoke(Ok(input))
                .Reduce(ok => ok, _ => -1)
                .Should().BeApproximately(expected, precision: 2);
        
        private static Result<double, string> TryParse(string input) =>
                double.TryParse(input, out double value)
                    ? value
                    : $"Input '{input}' failed to parse as double";
    }
}