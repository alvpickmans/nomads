namespace Nomads.Linq;

public class ResultTests
{
    [Fact]
    public void MapsResult_WithMapExtension()
    {
        // Arrange
        const double expectedValue = 6.28;
        
        // Act
        Result<double, string> valid = TryParse("3.14")
            .Map(x => x * 2);

        // Assert
        Assert.True(valid.HasValue);
        Assert.Equal(expectedValue, valid.Value, precision: 2);
    }
    
    [Fact]
    public void MapsErrorResult_WithMapExtension()
    {
        // Arrange
        const string expectedError = "Input '3 quarters' is not a number";
        
        // Act
        Result<double, string> invalid = TryParse("3 quarters")
            .Map(x => x * 2);
        
        // Assert
        Assert.False(invalid.HasValue);
        Assert.Equal(expectedError, invalid.Error);
    }
    
    [Fact]
    public void MapsResult_WithMapResultExtension()
    {
        // Arrange
        const double expectedValue = 3.14;
        
        // Act
        Result<double, string> result = Ok<string, string>("3.14")
            .Map(TryParse);
        
        // Assert
        Assert.True(result.HasValue);
        Assert.Equal(expectedValue, result.Value);
    }

    [Fact]
    public void MapsErrorResult_WithMapResultExtension()
    {
        // Arrange
        const string expectedError = "Unauthorized";
        
        // Act
        Result<double, string> result = Error<string, string>(expectedError)
            .Map(TryParse);
        
        // Assert
        Assert.False(result.HasValue);
        Assert.Equal(expectedError, result.Error);
    }
    
    private static Result<double, string> TryParse(string input) =>
        double.TryParse(input, out double value)
            ? value
            : $"Input '{input}' is not a number";

}