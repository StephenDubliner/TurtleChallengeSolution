using System.Collections.Generic;
using System.IO;
using TurtleChallenge.Library;
using Xunit;

namespace TurtleChallenge.Tests
{
    public class TurtleChallengeTests
    {
        private const string BoardConfigTestFile = @"TestData/game-settings.json";
        private const string SequencesTestFile = @"TestData/moves.json";
        
        private SessionDataProviderFromFiles testDataProvider;

        private Board Board => TestDataProvider.Board;

        private IEnumerable<string> Sequences => TestDataProvider.Sequences;

        SessionDataProviderFromFiles TestDataProvider
        {
            get
            {
                return testDataProvider ?? (testDataProvider = new SessionDataProviderFromFiles(new FileInfo(BoardConfigTestFile), new FileInfo(SequencesTestFile)));
            }
        }

        [Fact]
        public void WhenRunningAllSequencesTest()
        {
            // Arrange
            var session = new TurtleChallengeSession(new SessionDataProviderFromDTO(this.Board, this.Sequences));

            // Act
            var result = session.RunAll();
           
            // Assert
            Assert.True(result.GameOver);
            Assert.True(result.Escaped);
        }

        [Fact]
        public void WhenTurtleStepsOnMineTest()
        {
            // Arrange
            var session = new TurtleChallengeSession(new SessionDataProviderFromDTO(this.Board, this.Sequences));
        
            // Act
            var result = session.RunSequence(1);
        
            // Assert
            Assert.True(result.GameOver);
            Assert.False(result.Escaped);
        }
        
        [Fact]
        public void WhenTurtleStillInDangerTest()
        {
            // Arrange
            var session = new TurtleChallengeSession(new SessionDataProviderFromDTO(this.Board, this.Sequences));
        
            // Act
            var result = session.RunSequence(2);
        
            // Assert
            Assert.False(result.GameOver);
            Assert.False(result.Escaped);
        }

        [Fact]
        public void WhenTurtleEscapesTest()
        {
            // Arrange
            var session = new TurtleChallengeSession(new SessionDataProviderFromDTO(this.Board, this.Sequences));
        
            // Act
            var result = session.RunSequence(3);
        
            // Assert
            Assert.True(result.GameOver);
            Assert.True(result.Escaped);
        }
    }
}
