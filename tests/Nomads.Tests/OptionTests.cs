using Nomads.Primitives;

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
        Assert.True(option.HasValue);
        Assert.Equal(expected, option.Value);
    }
    
    [Fact]
    public void ShouldCreateEmptyOption()
    {
        // Act
        Option<string> option = None();

        // Assert
        Assert.False(option.HasValue);
        Assert.Throws<MemberAccessException>(() => option.Value);
    }

    [Fact]
    public void ShouldImplicitlyCreateOptionFromValue()
    {
        // Arrange
        int expected = 42;

        // Act
        Option<int> option = expected;

        // Assert
        Assert.True(option.HasValue);
        Assert.Equal(expected, option.Value);
    }

    [Fact]
    public void ShouldCreateImplicitOptionFromNone()
    {
        // Act
        Option<int> option = new None();

        // Assert
        Assert.False(option.HasValue);
        Assert.Throws<MemberAccessException>(() => option.Value);
    }
}