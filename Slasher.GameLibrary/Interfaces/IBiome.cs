using Slasher.GameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slasher.GameLibrary.Interfaces
{
    public interface IBiome
    {
        public string Name { get; }
        public Dictionary<TileType, int> TileTypeWeight { get; }

        int GetTotalWeight();
    }
}
