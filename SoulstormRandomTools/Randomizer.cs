using SoulstormRandomTools.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoulstormRandomTools
{
    public class Randomizer
    {
        private readonly RawRandomizer rawRandomizer = new RawRandomizer();

        private SoulstormItem[] RandomItems(List<string> args, SoulstormItemType itemType)
        {
            if (args.Count < 1)
                throw new Exception("No args provided!");
            //First arg, should be a number, so let's parse it!
            int count = 1;
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

            var returnString = new StringBuilder();

            //Let's parse race names now
            var choosenItems = new HashSet<SoulstormItem>();
            if (itemType == SoulstormItemType.Race)
            {
                foreach (var arg in args)
                {
                    try
                    {
                        var itemData = Extensions.raceArray.First(x => x.Key == arg);
                        choosenItems.Add(itemData);
                    }
                    catch { } //Incorrect item, skip it!
                }
                choosenItems.OrderBy(x => x.Key);
                var allowedRaces = choosenItems.Count != 0 ? choosenItems.ToArray() : Extensions.raceArray;
                var randomizedRaces = rawRandomizer.GenerateSoulstormItems(SoulstormItemType.Race, count, allowedRaces);
                return randomizedRaces;
            }
            else
            {
                foreach (var arg in args)
                {
                    try
                    {
                        var itemData = Extensions.mapArray.First(x => x.Key == arg);
                        choosenItems.Add(itemData);
                    }
                    catch { } //Incorrect item, skip it!
                }
                choosenItems.OrderBy(x => x.Key);
                var allowedMaps = choosenItems.Count != 0 ? choosenItems.ToArray() : Extensions.mapArray;
                var randomizedMaps = rawRandomizer.GenerateSoulstormItems(SoulstormItemType.Map, count, allowedMaps);
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
    }
}
