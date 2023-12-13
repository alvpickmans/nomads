namespace Nomads;

public class ResultTests
{
    [Fact]
    public void CreatesResult_WithOkConstructor()
    {
        // Arrange
        const string expected = "Success!";

        // Act
        Result<string, Exception> result = Ok(expected);

        // Assert
        Assert.True(result.HasValue);
        Assert.Equal(expected, result.Value);
        Assert.Null(result.Error);
    }
    
    [Fact]
    public void CreatesResult_WithImplicitConversion()
    {
        // Arrange
        const string expected = "Success!";

        // Act
        Result<string, Exception> result = expected;

        // Assert
        Assert.True(result.HasValue);
        Assert.Equal(expected, result.Value);
        Assert.Null(result.Error);
    }
    
    [Fact]
    public void CreatesErrorResult_WithErrorConstructor()
    {
        // Arrange
        const string message = "The operation failed";

        // Act
        Result<string, Exception> result = Error(new Exception(message));

        // Assert
        Assert.False(result.HasValue);
        Assert.Equal(message, result.Error!.Message);
        Assert.Equal(default, result.Value);
    }
    
    [Fact]
    public void CreatesErrorResult_WithImplicitConversion()
    {
        // Arrange
        const string message = "The operation failed";

        // Act
        Result<string, Exception> result = new Exception(message);

        // Assert
        Assert.False(result.HasValue);
        Assert.Equal(message, result.Error!.Message);
        Assert.Equal(default, result.Value);
    }

    [Fact]
    public void ResultEquals_WithOkConstructor()
    {
        // Arrange
        Result<string, Exception> result = "All good folks.";

        // Act
        string output = Ok("All good folks.") == result
            ? result.Value!
            : "err";

        // Assert
        Assert.Equal("All good folks.", output);
    }
    
    [Fact]
    public void ResultEquals_WithErrorConstructor()
    {
        // Arrange
        Result<string, int> result = -1;

        // Act
        string output = result == Error(-1)
            ? "err"
            : result.Value!;

        // Assert
        Assert.Equal("err", output);
    }
}