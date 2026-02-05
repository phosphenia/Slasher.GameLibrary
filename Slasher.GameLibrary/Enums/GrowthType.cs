namespace Slasher.GameLibrary.Enums
{
    public static class TileTypeToGrowthType
    {
        public static Dictionary<Enum, Enum> Dictionary = new Dictionary<Enum, Enum>() {
        { TileType.Empty, TileTypeGrowth.Empty},
        { TileType.Grass, TileTypeGrowth.SGrass},
        { TileType.Water, TileTypeGrowth.SWater},
        { TileType.Rock, TileTypeGrowth.SRock}};

        public enum TileTypeGrowth
        {
            Empty,
            SGrass,
            SWater,
            SRock
        }
    }
}