namespace TurtleChallenge.Library
{
    public class DirectionWest : DirectionBase
    {
        public override TileCoordinates Move(TileCoordinates fromTileCoordinates, Board board)
        {
            return new TileCoordinates(){X = Subtract(fromTileCoordinates.X , 1,board.Width), Y = fromTileCoordinates.Y};
        }

        public override DirectionBase Rotate()
        {
            return new DirectionNorth();
        }
    }
}