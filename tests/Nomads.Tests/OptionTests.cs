using FluentAssertions;
using None = Nomads.Primitives.None;

namespace Nomads;

public static class OptionTests
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
        public void with_None_constructor() =>
            None()
                .As<Option<string>>()
                .Should()
                .Be(new Option<string>());

        [Fact]
        public void from_implicit_value()
        {
            Option<int> option = 42;
            option.Should().Be(Some(42));
        }

        [Fact]
        public void from_implicit_None() =>
            new None()
                .As<Option<object>>()
                .Should().Be(new Option<object>());
    }


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


    public class Map
    {
        
        [Fact]
        public void with_value_type_delegates() =>
            Some("451")
                .Map(double.Parse)
                .Map(x => x - 32)
                .Map(x => x * 5.0)
                .Map(x => x / 9.0)
                .Reduce(-1)
                .Should().BeApproximately(232.778, precision: 3);

    [Fact]
    public void optional_delegate_returning_Some() =>
        Some("3.14")
            .MapOptional(TryParse)
            .Reduce(-1)
            .Should().BeApproximately(3.14, precision: 2);

    [Fact]
    public void optional_delegate_returning_None() =>
        Some("not a number")
            .MapOptional(TryParse)
            .Should().Be(None<double>());

    private static Option<double> TryParse(string input) =>
            double.TryParse(input, out double value)
                ? value
                : None();
    }
}