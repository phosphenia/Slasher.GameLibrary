using Slasher.GameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slasher.GameLibrary.Interfaces
{
    public interface IBiome
    {
        public string Name { get; }
        public abstract Dictionary<TileType, int> TileTypeWeight { get; }
        public int GetTotalWeight()
        {
            int totalWeight = 0;

            foreach (var item in TileTypeWeight)
            {
                totalWeight += item.Value;
            }
            return totalWeight;
        }
    }
}
