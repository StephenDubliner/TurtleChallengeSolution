using System.Runtime.Serialization;

namespace TurtleChallenge.Library
{
    [DataContract]
    public class TileCoordinates
    {
        [DataMember(Name = "x")]
        public int X { get; set; }
        
        [DataMember(Name = "y")]
        public int Y { get; set; }
        
        public static bool operator ==(TileCoordinates a, TileCoordinates b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        
        public static bool operator !=(TileCoordinates a, TileCoordinates b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return obj != null &&  this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}
