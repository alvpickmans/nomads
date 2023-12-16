namespace Nomads;

public static partial class ResultTests
{

    public class Reduce
    {
        [Fact]
        public void from_value_type_result() =>
            Ok<int, Exception>(42)
                .Reduce(
                    ok => ok.Should().Be(42),
                    _ => throw new Exception("Unexpected error branch"));

        [Fact]
        public void from_reference_type_result() =>
            Error<string, Exception>(new Exception("oh no!"))
                .Reduce(
                    _ => throw new Exception("Unexpected error branch"),
                    err => err.Message.Should().Be("oh no!")
                );
    }

}