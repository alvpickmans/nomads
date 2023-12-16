namespace Nomads;

public static partial class OptionTests
{

    public class Bind
    {
        
        [Theory]
        [InlineData("3.14", 3.14)]
        [InlineData("not a number", -1)]
        public void option_bound_to_delegate(Option<string> input, int expected) =>
            input
                .Bind(TryParse)
                .Reduce(-1)
                .Should().BeApproximately(expected, precision: 2);

        [Theory]
        [InlineData("3.14", 3.14)]
        [InlineData("not a number", -1)]
        public void delegate_bound_to_option(Option<string> input, int expected) =>
            Option.Bind((string x) => TryParse(x))
                .Invoke(input)
                .Reduce(-1)
                .Should().BeApproximately(expected, precision: 2);
        
        private static Option<double> TryParse(string input) =>
                double.TryParse(input, out double value)
                    ? value
                    : None();
    }
}
