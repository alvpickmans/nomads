namespace Nomads;

public static partial class OptionTests
{
    public class Map
    {
        [Fact]
        public void with_value_type_delegates() =>
            Some("451")
                .Map(double.Parse)
                .Map(x => x - 32)
                .Map(x => x * 5.0)
                .Map(x => x / 9.0)
                .Reduce(-1)
                .Should().BeApproximately(232.778, precision: 3);

    }
}