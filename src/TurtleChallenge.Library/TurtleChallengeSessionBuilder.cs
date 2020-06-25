using System;
using System.IO;
using System.Linq;

namespace TurtleChallenge.Library
{
    public interface ITurtleChallengeSessionBuilder
    {
        ITurtleChallengeSession Build();
    }
    
    public class TurtleChallengeSessionBuilder : ITurtleChallengeSessionBuilder
    {
        private readonly string[] args;
        
        public TurtleChallengeSessionBuilder(string[] args)
        {
            this.args = args;
        }
        
        public ITurtleChallengeSession Build()
        {
            if (args.Length != 2)
            {
                return new InvalidInputTurtleChallengeSession($"Invalid number of arguments: expected 3 actual {args.Length}.\nSample usage: dotnet TurtleChallenge.dll game-settings.json moves.json");
            }

            var notFound = args.Select(arg => new Tuple<bool, string>(!File.Exists(arg), arg));
            if (notFound.Any(arg => arg.Item1))
            {
                var toLabel = string.Join(",", notFound.Where(arg => arg.Item1).Select(arg => arg.Item2)); 
                
                return new InvalidInputTurtleChallengeSession($"Failed to read input files:{toLabel}.");
            }

            return new TurtleChallengeSession(new SessionDataProviderFromFiles(new FileInfo(args.FirstOrDefault()), new FileInfo(args.LastOrDefault())));
        }
    }
}