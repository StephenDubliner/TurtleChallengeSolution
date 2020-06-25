namespace TurtleChallenge.Library
{
    public class DirectionEast : DirectionBase
    {
        public override TileCoordinates Move(TileCoordinates fromTileCoordinates, Board board)
        {
            return new TileCoordinates(){X = this.Add(fromTileCoordinates.X,1,board.Width) , Y = fromTileCoordinates.Y };
        }

        public override DirectionBase Rotate()
        {
            return new DirectionSouth();
        }
    }
}