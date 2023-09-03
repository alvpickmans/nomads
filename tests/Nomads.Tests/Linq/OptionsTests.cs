namespace Nomads.Linq;

public class OptionsTests
{
    [Fact]
    public void ShouldMapWithSelector()
    {
        // Arrange
        const string farenheits = "451";
        const double expectedCelcius = 232.778;

        Func<string, Option<double>> farenheitToCelsius = fh => Some(fh)
            .Select(double.Parse)
            .Select(x => x - 32)
            .Select(x => x * 5.0)
            .Select(x => x / 9.0);

        // Act
        Option<double> celsius = farenheitToCelsius.Invoke(farenheits);

        // Assert
        Assert.True(celsius.HasValue);
        Assert.Equal(expectedCelcius, celsius.Value, precision: 3);
    }

    [Fact]
    public void ShouldMapWithSelectorReturningOption()
    {
        // Arrange
        Func<string, Option<double>> tryParse = input =>
            double.TryParse(input, out double value)
                ? value
                : None();

        // Act
        Option<double> invalid = Some("not a number")
            .Select(tryParse);
        
        Option<double> valid = Some("3.14")
            .Select(tryParse);

        // Assert
        Assert.False(invalid.HasValue);
        Assert.True(valid.HasValue);
        Assert.IsType<double>(valid.Value);
        Assert.Equal(3.14, valid.Value, precision: 2);
    }
}