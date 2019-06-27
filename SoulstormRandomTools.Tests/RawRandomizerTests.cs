using SoulstormRandomTools.Types;
using System;
using System.Linq;
using Xunit;

namespace SoulstormRandomTools.Tests
{
    public class RawRandomizerTests
    {
        private readonly RawRandomizer rawRandomizer = new RawRandomizer(new VanillaSoulstormItemsProvider());

        [Fact]
        public void TestGenerateRacesEmptyItems()
        {
            // Act
            var testItems = rawRandomizer.GenerateSoulstormItems(SoulstormItemType.Race);

            // Assert
            Assert.True(testItems.Length == 1 && testItems.All(x => rawRandomizer.ItemsProvider.Races.Contains(x)));
        }

        [Fact]
        public void TestGenerateMapsEmptyItems()
        {
            // Act
            var testItems = rawRandomizer.GenerateSoulstormItems(SoulstormItemType.Map);

            // Assert
            Assert.True(testItems.Length == 1 && testItems.All(x => rawRandomizer.ItemsProvider.Maps.Contains(x)));
        }

        [Fact]
        public void TestGenerateRaces()
        {
            // Arrange
            int count = 900;
            var items = new SoulstormItem[]
            {
                rawRandomizer.ItemsProvider.Races[0], rawRandomizer.ItemsProvider.Races[1]
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
                rawRandomizer.ItemsProvider.Races[0], rawRandomizer.ItemsProvider.Races[1]
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
            Assert.True(testItems.Length == rawRandomizer.ItemsProvider.Races.Length
                && Enumerable.SequenceEqual(testItems.OrderBy(x => x.Key), rawRandomizer.ItemsProvider.Races.OrderBy(x => x.Key)));
        }

        [Fact]
        public void TestShuffleMapsEmptyItems()
        {
            // Act
            var testItems = rawRandomizer.ShuffleSoulstormItems(SoulstormItemType.Map);

            // Assert
            Assert.True(testItems.Length == rawRandomizer.ItemsProvider.Maps.Length
                && Enumerable.SequenceEqual(testItems.OrderBy(x => x.Key), rawRandomizer.ItemsProvider.Maps.OrderBy(x => x.Key)));
        }

        [Fact]
        public void TestShuffleRaces()
        {
            // Arrange
            var items = new SoulstormItem[]
            {
                rawRandomizer.ItemsProvider.Races[2], rawRandomizer.ItemsProvider.Races[3], rawRandomizer.ItemsProvider.Races[2]
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
                rawRandomizer.ItemsProvider.Maps[2], rawRandomizer.ItemsProvider.Maps[3], rawRandomizer.ItemsProvider.Maps[3]
            };

            // Act
            var testItems = rawRandomizer.ShuffleSoulstormItems(SoulstormItemType.Map, items);

            // Assert
            Assert.True(testItems.Length == items.Length
                && Enumerable.SequenceEqual(testItems.OrderBy(x => x.Key), items.OrderBy(x => x.Key)));
        }
    }
}
