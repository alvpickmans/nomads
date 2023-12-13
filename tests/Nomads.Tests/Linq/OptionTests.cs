namespace Nomads.Linq;

public class OptionTests
{
    [Fact]
    public void MapsOption_WithMapValueExtension()
    {
        // Arrange
        const string farenheits = "451";
        const double expectedCelcius = 232.778;

        // Act
        Option<double> celsius = Some(farenheits)
            .Map(double.Parse)
            .Map(x => x - 32)
            .Map(x => x * 5.0)
            .Map(x => x / 9.0);

        // Assert
        Assert.True(celsius.HasValue);
        Assert.Equal(expectedCelcius, celsius.Value, precision: 3);
    }

    [Fact]
    public void MapsOption_WithMapOptionExtension()
    {
        // Act
        Option<double> option = Some("3.14")
            .Map(TryParse);

        // Assert
        Assert.True(option.HasValue);
        Assert.IsType<double>(option.Value);
        Assert.Equal(3.14, option.Value, precision: 2);
    }
    
    [Fact]
    public void MapsNoneOption_WithMapOptionExtension()
    {
        // Act
        Option<double> option = Some("not a number")
            .Map(TryParse);
        
        // Assert
        Assert.False(option.HasValue);
    }
    
    private static Option<double> TryParse(string input) =>
            double.TryParse(input, out double value)
                ? value
                : None();
}