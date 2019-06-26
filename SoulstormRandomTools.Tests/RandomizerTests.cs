using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SoulstormRandomTools.Tests
{
    public class RandomizerTests
    {
        private readonly Randomizer randomizer = new Randomizer();

        [Fact]
        public void TestEmptyArgs()
        {
            // Arrange
            var args = new string[] { };

            // Act & Assert
            Assert.Throws<Exception>(() => randomizer.RandomRaces(args));
        }


        [Fact]
        public void TestRacesWrongArgs()
        {
            // Arrange
            var args = new string[] { "f", "d" };

            // Act
            var testItems = randomizer.RandomRaces(args);

            // Assert
            Assert.True(testItems.Length == 1);
        }

        [Fact]
        public void TestMapsWrongArgs()
        {
            // Arrange
            var args = new string[] { "f", "d" };

            // Act
            var testItems = randomizer.RandomMaps(args);

            // Assert
            Assert.True(testItems.Length == 1);
        }

        [Fact]
        public void TestIntParsing()
        {
            // Arrange
            var args = new string[] { "5" };

            // Act
            var testItems = randomizer.RandomRaces(args);

            // Assert
            Assert.True(testItems.Length == 5);
        }

        [Fact]
        public void TestRacesFullArgs()
        {
            // Arrange
            var args = new string[] { "2", "sm", "csm", "tau" };

            // Act
            var testItems = randomizer.RandomRaces(args);

            // Assert
            Assert.True(testItems.Length == 2);
        }

        [Fact]
        public void TestMapsFullArgs()
        {
            // Arrange
            var args = new string[] { "3", "fm", "br", "or" };

            // Act
            var testItems = randomizer.RandomMaps(args);

            // Assert
            Assert.True(testItems.Length == 3);
        }

        [Fact]
        public void TestNoCountArg()
        {
            // Arrange
            var args = new string[] { "tau", "ig", "ork" };

            // Act
            var testItems = randomizer.RandomMaps(args);

            // Assert
            Assert.True(testItems.Length == 1);
        }
    }
}
