using System;
using System.Linq;

namespace TurtleChallenge.Library
{
    public interface ITurtleChallengeSession
    {
        IMoveOutcome RunAll();
        IMoveOutcome RunSequence(int sequenceNumber);
    }
    public class TurtleChallengeSession : ITurtleChallengeSession
    {
        private readonly ISessionDataProvider sessionDataProvider;
        private Turtle turtle;

        public TurtleChallengeSession(ISessionDataProvider sessionDataProvider)
        {
            this.sessionDataProvider = sessionDataProvider ?? throw new ArgumentNullException(nameof(sessionDataProvider));
        }

        protected Turtle Turtle
        {
            get
            {
                return turtle ?? (turtle = new Turtle(sessionDataProvider.Board.StartingTileCoordinates, (DirectionBase)sessionDataProvider.Board.StartDirection));
            }
        }

        protected void ResetTurtle() => this.turtle = null;
        
        private IMoveOutcome Execute(char move)
        {
            IMove actualMove;
            switch (move)
            {
                case 'm':
                    actualMove = new MoveForward(this.Turtle, sessionDataProvider.Board);
                    break;
                case 'r':
                    actualMove = new MoveRotate(this.Turtle);
                    break;
                default:
                    throw new ArgumentException(nameof(move));
            }

            var result = actualMove.Execute();
            return result;
        }

        public IMoveOutcome RunSequence(int sequenceNumber)
        {
            if (sequenceNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(sequenceNumber), "Must be greater than 0.");
            
            return this.RunSequence(sequenceNumber,
                this.sessionDataProvider.Sequences.Skip(sequenceNumber - 1).Take(1).FirstOrDefault());
        }

        private IMoveOutcome RunSequence(int sequenceNumber, string sessionMovesData)
        {
            if (sessionMovesData == null)
                throw new ArgumentNullException(nameof(sessionMovesData));

            IMoveOutcome result = null;
            using (var sessionsMovesEnumerator = sessionMovesData.ToLower().GetEnumerator())
            {
                this.ResetTurtle();
                IMoveOutcome moveOutcome = null;
                while (sessionsMovesEnumerator.MoveNext())
                {
                    moveOutcome = this.Execute(sessionsMovesEnumerator.Current);
                    if (moveOutcome.GameOver)
                    {
                        moveOutcome.ResolveOutcome(sequenceNumber);
                        break;
                    }
                }
                
                if (moveOutcome?.GameOver == false)
                {
                    moveOutcome.ResolveOutcome(sequenceNumber);
                }
                
                result = moveOutcome;
            }

            return result;
        }
        public IMoveOutcome RunAll()
        {
            IMoveOutcome result = null;
            try
            {
                using (var sessionsEnumerator = sessionDataProvider.Sequences.GetEnumerator())
                {
                    var sequenceNumber = 1;

                    while (sessionsEnumerator.MoveNext())
                    {
                        result = RunSequence(sequenceNumber, sessionsEnumerator.Current);
                        var sessionMoves = sessionsEnumerator.Current;
                        sequenceNumber++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }
    }
}