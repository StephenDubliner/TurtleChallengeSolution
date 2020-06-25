using System.Linq;

namespace TurtleChallenge.Library
{
    public class Turtle
    {
        private DirectionBase currentDirection;
        private TileCoordinates currentLocation;

        public Turtle(TileCoordinates startingTileCoordinates, DirectionBase startingDirection)
        {
            this.currentDirection = startingDirection;
            this.currentLocation = startingTileCoordinates;
        }
        
        public IMoveOutcome Move(Board givenBoard)
        {
            this.currentLocation = this.currentDirection.Move(this.currentLocation, givenBoard);
            if (givenBoard.ExitTileCoordinates == this.currentLocation)
            {
                return new MoveOutcomeSuccess();
            }
            
            if (givenBoard.Mines.Any(m => this.currentLocation ==  m))
            {
                return new MoveOutcomeMineHit();
            }
            
            return new MoveOutcomeDanger();
        }
        
        public IMoveOutcome Rotate()
        {
            this.currentDirection = this.currentDirection.Rotate();
            return new MoveOutcomeDanger();
        }
    }
}