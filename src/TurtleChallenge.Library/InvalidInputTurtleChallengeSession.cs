using System;

namespace TurtleChallenge.Library
{
    public class InvalidInputTurtleChallengeSession : ITurtleChallengeSession
    {
        private readonly string details;
        public InvalidInputTurtleChallengeSession(string details)
        {
            this.details = details;
        }

        public IMoveOutcome RunSequence(int sequenceNumber)
        {
            return this.RunAll();
        }
        
        public IMoveOutcome RunAll()
        {
            Console.WriteLine(this.details);
            return null;
        }
    }
}