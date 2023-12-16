namespace Nomads;

public static partial class OptionTests
{
    public class Reduce
    {
        [Fact]
        public void from_value_type_option() =>
            None<int>()
                .Reduce(-1)
                .Should().Be(-1);
        
        [Fact]
        public void from_reference_type_option() =>
            None<string>()
                .Reduce("fallback")
                .Should().Be("fallback");
        
        [Fact]
        public void from_value_type_option_and_delegate() =>
            None<bool>()
                .Reduce(() => true)
                .Should().Be(true);

        [Fact]
        public void from_reference_type_option_and_delegate() =>
            None<string>()
                .Reduce(() => "look ma, no hands")
                .Should().Be("look ma, no hands");
    }
}