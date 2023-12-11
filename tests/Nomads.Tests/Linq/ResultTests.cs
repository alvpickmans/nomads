namespace Nomads.Linq;

public class ResultTests
{
    [Fact]
    public void MapsResult_WithApplyExtension()
    {
        // Arrange
        const double expectedValue = 6.28;
        
        // Act
        Result<double, string> valid = TryParse("3.14")
            .Apply(x => x * 2);

        // Assert
        Assert.True(valid.HasValue);
        Assert.Equal(expectedValue, valid.Value, precision: 2);
    }
    
    [Fact]
    public void MapsErrorResult_WithApplyExtension()
    {
        // Arrange
        const string expectedError = "Input '3 quarters' is not a number";
        
        // Act
        Result<double, string> invalid = TryParse("3 quarters")
            .Apply(x => x * 2);
        
        // Assert
        Assert.False(invalid.HasValue);
        Assert.Equal(expectedError, invalid.Error);
    }
    
    [Fact]
    public void MapsResult_WithApplyorResultExtension()
    {
        // Arrange
        const double expectedValue = 3.14;
        
        // Act
        Result<double, string> result = Ok<string, string>("3.14")
            .Apply(TryParse);
        
        // Assert
        Assert.True(result.HasValue);
        Assert.Equal(expectedValue, result.Value);
    }

    [Fact]
    public void MapsErrorResult_WithApplyorResultExtension()
    {
        // Arrange
        const string expectedError = "Unauthorized";
        
        // Act
        Result<double, string> result = Error<string, string>(expectedError)
            .Apply(TryParse);
        
        // Assert
        Assert.False(result.HasValue);
        Assert.Equal(expectedError, result.Error);
    }
    
    private Result<double, string> TryParse(string input) =>
        double.TryParse(input, out var value)
            ? value
            : $"Input '{input}' is not a number";

}