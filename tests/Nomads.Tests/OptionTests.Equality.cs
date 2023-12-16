namespace Nomads;

public static partial class OptionTests
{

    public class Equality
    {
        [Fact]
        public void with_Some_instance()
        {
            Option<string> option = "All good folks.";
            string result = Some("All good folks.") == option
                ? "ok"
                : "err";

            result.Should().Be("ok");
        }
        
        [Fact]
        public void with_None_instance()
        {
            Option<string> option = "All good folks.";
            string result = None() == option
                ? "ok"
                : "err";

            result.Should().Be("err");
        }
    }

}