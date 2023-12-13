namespace Nomads;

public sealed class ResultExtensionsTests
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void MatchesDelegate_OnResult(bool okResult)
    {
        // Arrange
        const string firstName = "Bruce";
        string expected = okResult ? "Bruce Wayne" : "Bruce Banner";
        Result<string, string> result = okResult ? Ok(firstName) : Error(firstName);
        
        // Act 
        string value = result.Reduce(
            ok => $"{ok} Wayne",
            err => $"{err} Banner");
        
        // Assert
        Assert.Equal(expected, value);
    }
    
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void MatchesDelegate_OnResult_WithDifferentType(bool okResult)
    {
        // Arrange
        int expected = okResult ? 42 : -1;
        Result<string, string> result = okResult ? Ok("42") : Error("Something failed");
        
        // Act 
        int value = result.Reduce(
            int.Parse,
            _ => -1);
        
        // Assert
        Assert.Equal(expected, value);
    }
    
}