namespace Nomads;

public class ResultTests
{
    [Fact]
    public void ShouldCreateOkResultFromExtension()
    {
        // Arrange
        const string expected = "Success!";

        // Act
        Result<string, Exception> result = Ok(expected);

        // Assert
        Assert.False(result.HasError(out _));
        Assert.True(result.HasValue(out string? value));
        Assert.Equal(expected, value);
    }
    
    [Fact]
    public void ShouldCreateOkResultImplicit()
    {
        // Arrange
        const string expected = "Success!";

        // Act
        Result<string, Exception> result = expected;

        // Assert
        Assert.False(result.HasError(out _));
        Assert.True(result.HasValue(out string? value));
        Assert.Equal(expected, value);
    }
    
    [Fact]
    public void ShouldCreateErrorResultFromExtension()
    {
        // Arrange
        const string message = "The operation failed";

        // Act
        Result<string, Exception> result = Error(new Exception(message));

        // Assert
        Assert.False(result.HasValue(out _));
        Assert.True(result.HasError(out Exception? error));
        Assert.Equal(message, error!.Message);
    }
    
    [Fact]
    public void ShouldCreateErrorResultImplicit()
    {
        // Arrange
        const string message = "The operation failed";

        // Act
        Result<string, Exception> result = new Exception(message);

        // Assert
        Assert.False(result.HasValue(out _));
        Assert.True(result.HasError(out Exception? error));
        Assert.Equal(message, error!.Message);
    }
}