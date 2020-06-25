using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TurtleChallenge.Library
{
    [DataContract]
    public class Board
    {
        [DataMember(Name = "boardWidth")]
        public int Width { get; set; }
        
        [DataMember(Name = "boardHeight")]
        public int Height { get; set;}
        
        [DataMember(Name = "startingPoint")]
        public TileCoordinates StartingTileCoordinates { get; set; }
        
        [DataMember(Name = "exitPoint")]
        public TileCoordinates ExitTileCoordinates { get; set; }
        
        [DataMember(Name = "mines")]
        public IEnumerable<TileCoordinates> Mines { get; set; }
        
        [DataMember(Name = "startingDirection")]
        public string StartDirection { get; set; }
    }
}
