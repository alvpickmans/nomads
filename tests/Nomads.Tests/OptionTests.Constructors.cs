namespace Nomads;

public static partial class OptionTests
{
    public class Constructors
    {
        [Fact]
        public void with_Some_constructor() =>
            Some("Hi")
                .Reduce("err")
                .Should()
                .Be("Hi");

        [Fact]
        public void with_None_constructor()
        {
            Option<string> none = new None();
            none.Should().Be(new None<string>());
        }

        [Fact]
        public void from_implicit_value()
        {
            Option<int> option = 42;
            option.Should().Be(Some(42));
        }
    }
}