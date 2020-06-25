using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TurtleChallenge.Library
{
    public class SessionDataProviderFromFiles : SessionDataProviderFromDTO, ISessionDataProvider
    {
        public SessionDataProviderFromFiles(FileInfo boardFile, FileInfo movesFile):base(
            JsonConvert.DeserializeObject<Board>(File.ReadAllText(boardFile.FullName)),
            JsonConvert.DeserializeObject<IEnumerable<string>>(File.ReadAllText(movesFile.FullName))
        )
        {
        }
    }
}