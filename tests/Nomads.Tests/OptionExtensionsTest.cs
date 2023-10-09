namespace Nomads;

public sealed class OptionExtensionsTest
{
    [Fact]
    public void ReturnsFallbackValue_OnEmptyOption()
    {
        // Arrange
        Option<string> option = None();
        
        // Act
        string value = option.ValueOrElse("look ma, no hands");
        
        // Assert
        Assert.Equal("look ma, no hands", value);

    }
}