using SoulstormRandomTools.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SoulstormRandomTools.Tests
{
    public class RawRandomizerTests
    {
        private readonly RawRandomizer rawRandomizer = new RawRandomizer();

        [Fact]
        public void TestGenerateRacesEmptyItems()
        {
            // Act
            var testItems = rawRandomizer.GenerateSoulstormItems(SoulstormItemType.Race);

            // Assert
            Assert.True(testItems.Length == 1 && testItems.All(x => Extensions.raceArray.Contains(x)));
        }

        [Fact]
        public void TestGenerateMapsEmptyItems()
        {
            // Act
            var testItems = rawRandomizer.GenerateSoulstormItems(SoulstormItemType.Map);

            // Assert
            Assert.True(testItems.Length == 1 && testItems.All(x => Extensions.mapArray.Contains(x)));
        }

        [Fact]
        public void TestGenerateRaces()
        {
            // Arrange
            int count = 900;
            var items = new SoulstormItem[]
            {
                Extensions.raceArray[0], Extensions.raceArray[1]
            };

            // Act
            var testItems = rawRandomizer.GenerateSoulstormItems(SoulstormItemType.Race, count, items);

            // Assert
            Assert.True(testItems.Length == count && testItems.All(x => items.Contains(x)));
        }

        [Fact]
        public void TestGenerateMaps()
        {
            // Arrange
            int count = 950;
            var items = new SoulstormItem[]
            {
                Extensions.mapArray[0], Extensions.mapArray[1]
            };

            // Act
            var testItems = rawRandomizer.GenerateSoulstormItems(SoulstormItemType.Map, count, items);

            // Assert
            Assert.True(testItems.Length == count && testItems.All(x => items.Contains(x)));
        }

        [Fact]
        public void TestShuffleRacesEmptyItems()
        {
            // Act
            var testItems = rawRandomizer.ShuffleSoulstormItems(SoulstormItemType.Race);

            // Assert
            Assert.True(testItems.Length == Extensions.raceArray.Length
                && Enumerable.SequenceEqual(testItems.OrderBy(x => x.Key), Extensions.raceArray.OrderBy(x => x.Key)));
        }

        [Fact]
        public void TestShuffleMapsEmptyItems()
        {
            // Act
            var testItems = rawRandomizer.ShuffleSoulstormItems(SoulstormItemType.Map);

            // Assert
            Assert.True(testItems.Length == Extensions.mapArray.Length
                && Enumerable.SequenceEqual(testItems.OrderBy(x => x.Key), Extensions.mapArray.OrderBy(x => x.Key)));
        }

        [Fact]
        public void TestShuffleRaces()
        {
            // Arrange
            var items = new SoulstormItem[]
            {
                Extensions.raceArray[2], Extensions.raceArray[3]
            };

            // Act
            var testItems = rawRandomizer.ShuffleSoulstormItems(SoulstormItemType.Race, items);

            // Assert
            Assert.True(testItems.Length == items.Length
                && Enumerable.SequenceEqual(testItems.OrderBy(x => x.Key), items.OrderBy(x => x.Key)));
        }

        [Fact]
        public void TestShuffleMaps()
        {
            // Arrange
            var items = new SoulstormItem[]
            {
                Extensions.mapArray[2], Extensions.mapArray[3]
            };

            // Act
            var testItems = rawRandomizer.ShuffleSoulstormItems(SoulstormItemType.Map, items);

            // Assert
            Assert.True(testItems.Length == items.Length
                && Enumerable.SequenceEqual(testItems.OrderBy(x => x.Key), items.OrderBy(x => x.Key)));
        }
    }
}
