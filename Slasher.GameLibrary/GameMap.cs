
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
            GenerateRandomMap(biome);
        }

        private void GenerateRandomMap(IBiome biome)
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
    }
}
