using System.Collections.Generic;

namespace TurtleChallenge.Library
{
    public interface ISessionDataProvider
    {
        Board Board { get; }
        IEnumerable<string> Sequences { get; }
    }

    public class SessionDataProviderFromDTO : ISessionDataProvider
    {
        public Board Board { get; }
        public IEnumerable<string> Sequences { get; }

        public SessionDataProviderFromDTO(Board board, IEnumerable<string> sequences)
        {
            this.Board = board;
            this.Sequences = sequences;
        }
    }
}