using SoulstormRandomTools.Types;
using System;

namespace SoulstormRandomTools
{
    public class RawRandomizer
    {
        private readonly Random rand = new Random();
        public SoulstormItem[] GenerateSoulstormItems(SoulstormItemType itemsType, int count = 1, SoulstormItem[] items = null)
        {
            if (count < 1)
                count = 1;
            if (count > 1000)
                count = 1000;

            if (items == null || items.Length == 0)
            {
                if (itemsType == SoulstormItemType.Race)
                    items = Extensions.raceArray;
                else if(itemsType == SoulstormItemType.Map)
                    items = Extensions.mapArray;
            }

            var returnItems = new SoulstormItem[count];
            for (int i = 0; i < count; i++)
            {
                returnItems[i] = items[rand.Next(items.Length)];
            }
            return returnItems;
        }

        public SoulstormItem[] ShuffleSoulstormItems(SoulstormItemType itemsType, SoulstormItem[] items = null)
        {
            if (items == null || items.Length == 0)
            {
                if (itemsType == SoulstormItemType.Race)
                    items = Extensions.raceArray;
                else if (itemsType == SoulstormItemType.Map)
                    items = Extensions.mapArray;
            }
            Extensions.Shuffle(items);

            return items;
        }
    }
}
