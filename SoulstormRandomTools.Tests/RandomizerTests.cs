using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SoulstormRandomTools.Tests
{
    public class RandomizerTests
    {
        private readonly Randomizer randomizer = new Randomizer(new VanillaSoulstormItemsProvider());

        [Fact]
        public void TestRacesEmptyArgs()
        {
            // Arrange
            var args = new string[] { };

            // Act & Assert
            Assert.Throws<Exception>(() => randomizer.RandomRaces(args));
        }


        [Fact]
        public void TestMapsEmptyArgs()
        {
            // Arrange
            var args = new string[] { };

            // Act & Assert
            Assert.Throws<Exception>(() => randomizer.RandomMaps(args));
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

    }
}
