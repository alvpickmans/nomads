namespace Nomads;

public static partial class ResultTests
{
    public class Equality
    {
    
        [Fact]
        public void with_Ok_instance()
        {
            Result<string, Exception> result = "All good folks.";
            string output = Ok("All good folks.") == result
                ? "ok"
                : "err";

            output.Should().Be("ok");
        }
        
    
        [Fact]
        public void with_Error_instance()
        {
            Result<string, int> result = -1;
            string output = Error(-1) == result
                ? "err"
                : "ok";

            output.Should().Be("err");
        }
    }

}