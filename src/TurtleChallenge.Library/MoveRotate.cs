namespace TurtleChallenge.Library
{
    public class MoveRotate : IMove
    {
        private readonly Turtle turtle;
        public MoveRotate(Turtle turtle)
        {
            this.turtle = turtle;
        }
        
        public IMoveOutcome Execute()
        {
            return this.turtle.Rotate();
        }
    }
}