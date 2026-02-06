using Slasher.GameLibrary.Enums;
using Slasher.GameLibrary.Interfaces;
using System;

namespace Slasher.GameLibrary;

public class GameMap
{
    public Enum[,] Tiles { get; set; }

    public GameMap(int width, int height, IBiome biome)
    {
        Tiles = new Enum[width, height];
        GenerateBaseMap(biome);
        GrowAllTiles();
        GeneralizeAllTiles();
    }

    private void GenerateBaseMap(IBiome biome)
    {

        int totalWeight = biome.GetTotalWeight();
        var possibleValues = Enum.GetValues<TileType>();
        int runningTotalWeight = 0;
        Dictionary<int, TileType> tileBoundaryList = new();

        foreach (var item in biome.TileTypeWeight)
        {
            runningTotalWeight += item.Value;
            tileBoundaryList.Add(runningTotalWeight, item.Key);
        }

        tileBoundaryList.OrderDescending();

        for (int x = 0; x < Tiles.GetLength(0); x++)
        {
            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                int randomNumber = Random.Shared.Next(totalWeight);
                
                Tiles[x, y] = tileBoundaryList.SkipWhile(x => x.Key <= randomNumber).FirstOrDefault().Value;
                
            }
        }
    }

    private void GrowAllTiles()
    {
        for (int x = 0; x < Tiles.GetLength(0); x++)
        {
            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                if (Tiles[x, y] is TileType)
                {
                    if (GrowableData.CanGrow(Tiles[x, y]))
                    {
                        GrowTile(x, y);
                    }
                }
            }
        }
    }

    private void GrowTile(int x, int y)
    {
        Enum coreType = Tiles[x, y];
        GrowthTileType growthType = (GrowthTileType)coreType;
        (int, int)[] surroundingTiles = GetSurroundingTiles(x, y);

        foreach ((int, int) item in surroundingTiles)
        {
            if (item.Item1 - x == 0 && 0 < item.Item2 && item.Item2 < y)
            {
                Tiles[item.Item1, item.Item2] = growthType;
            }
            else if (item.Item1 < x)
            {
                Tiles[item.Item1, item.Item2] = growthType;
            }
        }

        //x + 1 Tile
        if (Tiles.GetLength(0) > x + 1)
        {
            Tiles[x + 1, y] = growthType;
        }

        //y + 1 Tile
        if (Tiles.GetLength(1) > y + 1)
        { 
            Tiles[x, y + 1] = growthType;
        }

        //y - 1 Tile
        if (y > 0)
        {
            Tiles[x, y - 1] = growthType;
        }

        //x - 1 Tile
        if (x > 0)
        {
            Tiles[x - 1, y] = growthType;
        }
    }

    //For later growth possibilities
    private void GeneralizeAllTiles()
    {
        for(int x = 0; x < Tiles.GetLength(0); x++)
        {
            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                GeneralizeTile(x, y);
            }
        }
    }

    private void GeneralizeTile(int x, int y)
    {
        if (Tiles[x, y] is not TileType)
        {
            Tiles[x, y] = (TileType) Tiles[x, y];
        }
    }

    private (int, int)[] GetSurroundingTiles(int x, int y)
    {
        return new (int x, int y)[]
        {
            (x + 1, y), (x - 1, y), (x, y + 1), (x, y - 1) 
        };

    }
}
