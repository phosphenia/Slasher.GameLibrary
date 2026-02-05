using Slasher.GameLibrary.Enums;
using Slasher.GameLibrary.Interfaces;

namespace Slasher.GameLibrary
{
    public class GameMap
    {
        public TileType[,] Tiles { get; set; }

        public GameMap(int width, int height, IBiome biome)
        {
            Tiles = new TileType[width, height];
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
                    if ((TileType)Tiles[x, y] != TileType.Empty && (int)Tiles[x, y] % 2 == 1)
                    {
                        GrowTile(x, y);
                    }
                }
            }
        }

        private void GrowTile(int x, int y)
        {
            TileType coreType = (TileType)Tiles[x, y];
            TileType growthType = (TileType)((int) coreType + 1);
            if (Tiles.GetLength(0) > x + 1 && Tiles[x + 1, y] == TileType.Empty)
            {
                Tiles[x + 1, y] = growthType;
            }
            if (Tiles.GetLength(1) > y + 1 && (TileType) Tiles[x, y + 1] == TileType.Empty)
            {
                Tiles[x, y + 1] = growthType;
            }
            if (y > 0 && (TileType) Tiles[x, y - 1] == TileType.Empty)
            {
                Tiles[x, y - 1] = growthType;
            }
            if (x > 0 && (TileType) Tiles[x - 1, y] == TileType.Empty)
            {
                Tiles[x - 1, y] = growthType;
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
            if ((TileType) Tiles[x, y] != TileType.Empty && (int)Tiles[x, y] % 2 == 0)
            {
                Tiles[x, y] = (TileType)((int)Tiles[x, y] - 1);
            }
        }
    }
}
