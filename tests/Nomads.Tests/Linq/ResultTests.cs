namespace Nomads.Linq;

public class ResultTests
{
    [Fact]
    public void ShouldMapWithSelector()
    {
        // Arrange
        const string expectedError = "Input '3 quarters' is not a number";
        const double expectedValue = 6.28;
        
        // Act
        Result<double, string> invalid = TryParse("3 quarters")
            .Select(x => x * 2);
        
        Result<double, string> valid = TryParse("3.14")
            .Select(x => x * 2);

        // Assert
        Assert.False(invalid.HasValue);
        Assert.Equal(expectedError, invalid.Error);
        
        Assert.True(valid.HasValue);
        Assert.Equal(expectedValue, valid.Value, precision: 2);
    }

    [Fact]
    public void ShouldMapWithSelectorReturningResult()
    {
        // Arrange
        const string expectedError = "Unauthorized";
        const double expectedValue = 3.14;
        
        // Act
        Result<double, string> invalid = Error<string, string>(expectedError)
            .Select(TryParse);
        
        Result<double, string> valid = Ok<string, string>("3.14")
            .Select(TryParse);
        
        // Assert
        Assert.False(invalid.HasValue);
        Assert.Equal(expectedError, invalid.Error);
        
        Assert.True(valid.HasValue);
        Assert.Equal(expectedValue, valid.Value);
    }
    
    private Result<double, string> TryParse(string input) =>
        double.TryParse(input, out var value)
            ? value
            : $"Input '{input}' is not a number";

}