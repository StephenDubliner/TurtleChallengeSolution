using System;

namespace TurtleChallenge.Library
{
    public abstract class DirectionBase
    {
        public abstract TileCoordinates Move(TileCoordinates fromTileCoordinates, Board board);

        public abstract DirectionBase Rotate();
        
        public static explicit operator DirectionBase(string directionSymbol)  // explicit byte to digit conversion operator
        {
            if (directionSymbol == null)
                throw new ArgumentNullException(nameof(directionSymbol));
            if(directionSymbol=="N")
                return new DirectionNorth();
            if(directionSymbol=="S")
                return new DirectionSouth();
            if(directionSymbol=="E")
                return new DirectionEast();
            if(directionSymbol=="W")
                return new DirectionWest();
            throw new InvalidCastException(nameof(directionSymbol));
        }
        
        protected int Subtract(int from, int value, int fallback)
        {
            return from - value < 0 ? fallback -1 - (Math.Abs(from - value) - 1): from - value;
        }
        
        protected int Add(int from, int value, int fallback)
        {
            return (from + value) % (fallback);
        }
    }
}