namespace TurtleChallenge.Library
{
    public class DirectionSouth : DirectionBase
    {
        public override TileCoordinates Move(TileCoordinates fromTileCoordinates, Board board)
        {
            return new TileCoordinates(){X = fromTileCoordinates.X, Y = this.Add(fromTileCoordinates.Y,1,board.Height)};
        }

        public override DirectionBase Rotate()
        {
            return new DirectionWest();
        }
    }
}