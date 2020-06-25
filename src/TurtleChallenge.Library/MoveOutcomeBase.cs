using System;

namespace TurtleChallenge.Library
{
    public interface IMoveOutcome
    {
        bool GameOver { get; }
        bool Escaped { get; }
        bool ResolveOutcome(int sequenceNumber);
    }
    
    public abstract class MoveOutcomeBase{
        protected abstract string Status { get; }

        public virtual bool ResolveOutcome(int sequenceNumber)
        {
            Console.WriteLine($"Sequence {sequenceNumber}: {this.Status}!");

            return true;
        }
    }
}