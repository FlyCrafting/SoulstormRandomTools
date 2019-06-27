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
        public void TestShuffleRacesWrongArgs()
        {
            // Arrange
            var args = new string[] { "f", "d" };

            // Act
            var testItems = randomizer.ShuffleRaces(args);

            // Assert
            Assert.True(testItems.Length == randomizer.ItemsProvider.Races.Length);
        }


        [Fact]
        public void TestShuffleMapsWrongArgs()
        {
            // Arrange
            var args = new string[] { "f", "d" };

            // Act
            var testItems = randomizer.ShuffleMaps(args);

            // Assert
            Assert.True(testItems.Length == randomizer.ItemsProvider.Maps.Length);
        }

    }
}
