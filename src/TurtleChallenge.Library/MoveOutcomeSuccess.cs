namespace TurtleChallenge.Library
{
    public class MoveOutcomeSuccess : MoveOutcomeBase, IMoveOutcome
    {
        public bool GameOver => true;
        public bool Escaped => true;
        protected override string Status => "Success";
    }
}