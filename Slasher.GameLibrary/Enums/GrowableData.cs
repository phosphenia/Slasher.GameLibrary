using System;
using System.Collections.Generic;
using System.Text;

namespace Slasher.GameLibrary.Enums;

public static class GrowableData
{
    private static Dictionary<TileType, bool> _tileType = new()
    {
        { TileType.Empty, false },
        { TileType.Grass, true },
        { TileType.Water, true },
        { TileType.Rock, true }
    };

    private static Dictionary<GrowthTileType, bool> _growthTileType = new()
    {
        { GrowthTileType.Empty, false },
        { GrowthTileType.Grass, false },
        { GrowthTileType.Water, false },
        { GrowthTileType.Rock, false }
    };

    public static bool CanGrow(Enum tileType)
    {
        if (tileType is TileType tile)
        {
            return _tileType.TryGetValue(tile, out var canGrow) && canGrow;
        }
        else if (tileType is GrowthTileType growthTile)
        {
            return _growthTileType.TryGetValue(growthTile, out var canGrow) && canGrow;
        }
        else
        {
            throw new ArgumentException("Unsupported enum type", nameof(tileType));
        }
    }
}
