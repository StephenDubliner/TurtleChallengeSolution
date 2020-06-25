namespace TurtleChallenge.Library
{
    public class DirectionNorth : DirectionBase
    {
        public override TileCoordinates Move(TileCoordinates fromTileCoordinates, Board board)
        {
            return new TileCoordinates{X = fromTileCoordinates.X, Y = this.Subtract(fromTileCoordinates.Y, 1,board.Height) };
        }

        public override DirectionBase Rotate()
        {
            return new DirectionEast();
        }
    }
}