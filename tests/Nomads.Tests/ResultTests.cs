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
        Assert.True(result.HasValue);
        Assert.Equal(expected, result.Value);
        Assert.Throws<MemberAccessException>(() => result.Error);
    }
    
    [Fact]
    public void ShouldCreateOkResultImplicit()
    {
        // Arrange
        const string expected = "Success!";

        // Act
        Result<string, Exception> result = expected;

        // Assert
        Assert.True(result.HasValue);
        Assert.Equal(expected, result.Value);
        Assert.Throws<MemberAccessException>(() => result.Error);
    }
    
    [Fact]
    public void ShouldCreateErrorResultFromExtension()
    {
        // Arrange
        const string message = "The operation failed";

        // Act
        Result<string, Exception> result = Error(new Exception(message));

        // Assert
        Assert.False(result.HasValue);
        Assert.Equal(message, result.Error!.Message);
        Assert.Throws<MemberAccessException>(() => result.Value);
    }
    
    [Fact]
    public void ShouldCreateErrorResultImplicit()
    {
        // Arrange
        const string message = "The operation failed";

        // Act
        Result<string, Exception> result = new Exception(message);

        // Assert
        Assert.False(result.HasValue);
        Assert.Equal(message, result.Error!.Message);
        Assert.Throws<MemberAccessException>(() => result.Value);
    }
}