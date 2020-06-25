namespace TurtleChallenge.Library
{
    public interface IMove
    {
        IMoveOutcome Execute();
    }
    
    public class MoveForward : IMove
    {
        private readonly Turtle turtle;
        private readonly Board board;
        
        public MoveForward(Turtle turtle, Board board)
        {
            this.turtle = turtle;
            this.board = board;
        }
        public IMoveOutcome Execute()
        {
            return  this.turtle.Move(this.board);
        }
    }
}