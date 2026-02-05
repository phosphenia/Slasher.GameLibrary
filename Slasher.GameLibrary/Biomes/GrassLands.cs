using Slasher.GameLibrary.Enums;
using Slasher.GameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slasher.GameLibrary.Biomes
{
    public  class GrassLands : IBiome
    {
        public string Name { get; } = "Grass Lands";
        public Dictionary<TileType, int> TileTypeWeight { get; } = new()
        {
            {TileType.Empty, 95 },
            {TileType.Grass, 3 },
            {TileType.Water, 1 },
            {TileType.Rock, 1 }
        };
    }
}
