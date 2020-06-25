namespace TurtleChallenge.Library
{
    public class MoveOutcomeDanger : MoveOutcomeBase, IMoveOutcome
    {
        public bool GameOver => false;
        public bool Escaped => false;

        protected override string Status => "Still in danger";
    }
}