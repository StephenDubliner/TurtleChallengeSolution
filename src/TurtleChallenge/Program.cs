using TurtleChallenge.Library;

namespace TurtleChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            new TurtleChallengeSessionBuilder(args)
                .Build()
                .RunAll();
        }
    }
}
