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
        GrowthTileType growthType = (GrowthTileType) Tiles[x, y];
        (int, int)[] surroundingTiles = GetSurroundingTiles(x, y);

        foreach ((int sx, int sy) in surroundingTiles)
        {
            if (sx >= 0 && sx < Tiles.GetLength(0) && sy >= 0 && sy < Tiles.GetLength(1))
            {
                Tiles[sx, sy] = growthType;
            }
        }
    }
    
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
