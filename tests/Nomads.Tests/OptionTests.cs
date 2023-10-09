using Nomads.Primitives;

namespace Nomads;

public class OptionTests
{
    [Fact]
    public void CreatesOption_WithSomeConstructor()
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
    public void CreatesEmptyOption_WithNoneConstructor()
    {
        // Act
        Option<string> option = None();

        // Assert
        Assert.False(option.HasValue);
        Assert.Null(option.Value);
    }

    [Fact]
    public void CreatesOption_WithImplicitConversion()
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
    public void CreatesEmptyOption_WithImplicitNoneOperator()
    {
        // Act
        Option<int> option = new None();

        // Assert
        Assert.False(option.HasValue);
        Assert.Equal(default, option.Value);
    }

    [Fact]
    public void OptionEquals_WithSomeConstructor()
    {
        // Arrange
        Option<string> option = "All good folks.";

        // Act
        string result = Some("All good folks.") == option
            ? option.Value!
            : "err";

        // Assert
        Assert.Equal("All good folks.", result);
    }
    
    [Fact]
    public void OptionEquals_WithNoneConstructor()
    {
        // Arrange
        Option<string> option = "All good folks.";

        // Act
        string result = None() == option
            ? option.Value!
            : "err";

        // Assert
        Assert.Equal("err", result);
    }
}