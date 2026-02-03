using Slasher.GameLibrary.Enums;
using Slasher.GameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slasher.GameLibrary.Biomes
{
    public class GrassLands : IBiome
    {
        public string Name { get; } = "Grass Lands";
        public Dictionary<TileType, int> TileTypeWeight { get; } = new()
        {
            {TileType.Empty, 70 },
            {TileType.Grass, 20 },
            {TileType.Water, 7 },
            {TileType.Rock, 3 }
        };
        
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
