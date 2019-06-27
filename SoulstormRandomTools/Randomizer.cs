using SoulstormRandomTools.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoulstormRandomTools
{
    public class Randomizer
    {
        private readonly RawRandomizer rawRandomizer;
        public ISoulstormItemsProvider ItemsProvider { get; }

        public Randomizer(ISoulstormItemsProvider soulstormItemsProvider)
        {
            ItemsProvider = soulstormItemsProvider;
            rawRandomizer = new RawRandomizer(soulstormItemsProvider);
        }

        private SoulstormItem[] RandomItems(List<string> args, SoulstormItemType itemType)
        {
            //First arg, should be a number, so let's parse it!
            int count = 1;
            if (args.Count >= 1)
            {
                try
                {
                    count = Convert.ToInt32(args[0]);
                    if (count < 1)
                        count = 1;
                    if (count > 81)
                        count = 81;
                    args.RemoveAt(0);
                }
                catch { } //No number found, so use default
            }

            var returnString = new StringBuilder();

            //Let's parse race names now
            var choosenItems = new HashSet<SoulstormItem>();
            if (itemType == SoulstormItemType.Race)
            {
                foreach (var arg in args)
                {
                    try
                    {
                        var itemData = ItemsProvider.Races.First(x => x.Key == arg);
                        choosenItems.Add(itemData);
                    }
                    catch { } //Incorrect item, skip it!
                }
                var randomizedRaces = rawRandomizer.GenerateSoulstormItems(SoulstormItemType.Race, count, choosenItems.ToArray());
                return randomizedRaces;
            }
            else
            {
                foreach (var arg in args)
                {
                    try
                    {
                        var itemData = ItemsProvider.Maps.First(x => x.Key == arg);
                        choosenItems.Add(itemData);
                    }
                    catch { } //Incorrect item, skip it!
                }
                var randomizedMaps = rawRandomizer.GenerateSoulstormItems(SoulstormItemType.Map, count, choosenItems.ToArray());
                return randomizedMaps;
            }

        }

        public SoulstormItem[] RandomRaces(string[] args)
        {
            try
            {
                return RandomItems(args.ToList(), SoulstormItemType.Race);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SoulstormItem[] RandomMaps(string[] args)
        {
            try
            {
                return RandomItems(args.ToList(), SoulstormItemType.Map);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private SoulstormItem[] ShuffleItems(List<string> args, SoulstormItemType itemType)
        {
            var shuffleItems = new List<SoulstormItem>();
            if (itemType == SoulstormItemType.Race)
            {
                foreach (var arg in args)
                {
                    try
                    {
                        var itemData = ItemsProvider.Races.First(x => x.Key == arg);
                        shuffleItems.Add(itemData);
                    }
                    catch { } //Incorrect item, skip it!
                }
                var randomizedRaces = rawRandomizer.ShuffleSoulstormItems(SoulstormItemType.Race, shuffleItems.ToArray());
                return randomizedRaces;
            }
            else
            {
                foreach (var arg in args)
                {
                    try
                    {
                        var itemData = ItemsProvider.Maps.First(x => x.Key == arg);
                        shuffleItems.Add(itemData);
                    }
                    catch { } //Incorrect item, skip it!
                }
                var randomizedMaps = rawRandomizer.ShuffleSoulstormItems(SoulstormItemType.Map, shuffleItems.ToArray());
                return randomizedMaps;
            }
        }

        public SoulstormItem[] ShuffleRaces(string[] args)
        {
            try
            {
                return ShuffleItems(args.ToList(), SoulstormItemType.Race);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SoulstormItem[] ShuffleMaps(string[] args)
        {
            try
            {
                return ShuffleItems(args.ToList(), SoulstormItemType.Map);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
