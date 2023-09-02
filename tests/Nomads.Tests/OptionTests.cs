namespace Nomads;

public class OptionTests
{
    [Fact]
    public void ShouldCreateOption()
    {
        // Arrange
        const string expected = "Hi";
        
        // Act
        Option<string> option = Some(expected);

        // Assert
        Assert.True(option.HasValue(out string? value));
        Assert.Equal(expected, value);
    }

    [Fact]
    public void ShouldImplicitlyCreateOptionFromValue()
    {
        // Arrange
        int expected = 42;

        // Act
        Option<int> option = expected;

        // Assert
        Assert.True(option.HasValue(out var value));
        Assert.Equal(expected, value);
    }

    [Fact]
    public void ShouldCreateImplicitOptionFromNone()
    {
        // Act
        Option<int> option = None();

        // Assert
        Assert.False(option.HasValue());
    }
}