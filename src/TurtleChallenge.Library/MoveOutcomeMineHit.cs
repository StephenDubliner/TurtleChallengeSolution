namespace TurtleChallenge.Library
{
    public class MoveOutcomeMineHit : MoveOutcomeBase, IMoveOutcome
    {
        public bool GameOver  => true;
        public bool Escaped => false;

        protected override string Status => "Mine hit";
    }
}