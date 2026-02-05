using Slasher.GameLibrary.Enums;
using Slasher.GameLibrary.Interfaces;
using static Slasher.GameLibrary.Enums.TileTypeToGrowthType;

namespace Slasher.GameLibrary
{
    public class GameMap
    {
        public Enum[,] Tiles { get; set; }

        public GameMap(int width, int height, IBiome biome)
        {
            Tiles = new Enum[width, height];
            GenerateBaseMap(biome);
            GrowAllTiles();
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
                    
                    Tiles[x, y] = tileBoundaryList.SkipWhile(x => x.Key < randomNumber).FirstOrDefault().Value;
                    
                }
            }
        }
        private void GrowAllTiles()
        {
            for (int x = 0; x < Tiles.GetLength(0); x++)
            {
                for (int y = 0; y < Tiles.GetLength(1); y++)
                {
                    if ((TileType)Tiles[x, y] != TileType.Empty)
                    {
                        GrowTile((TileType)Tiles[x, y], x, y);
                    }
                }
            }
        }

        private void GrowTile(TileType coreType, int x, int y)
        {
            TileTypeGrowth growthType = (TileTypeGrowth)coreType;
            if (Tiles.GetLength(0) > x + 1 && Tiles[x + 1, y] == (Enum) TileType.Empty)
            {
                Tiles[x + 1, y] = growthType;
            }
            if (Tiles.GetLength(1) > y + 1 && Tiles[x, y + 1] == (Enum) TileType.Empty)
            {
                Tiles[x, y + 1] = growthType;
            }
            if (y > 0 && Tiles[x, y - 1] == (Enum) TileType.Empty)
            {
                Tiles[x, y - 1] = growthType;
            }
            if (x > 0 && Tiles[x - 1, y] == (Enum) TileType.Empty)
            {
                Tiles[x - 1, y] = growthType;
            }
        }
    }
}
