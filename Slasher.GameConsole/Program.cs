using Slasher.GameConsole.Visualizers;
using Slasher.GameLibrary;
using Slasher.GameLibrary.Biomes;
using Slasher.GameLibrary.Interfaces;
using Slasher.GameLibrary.Enums;

namespace Slasher.GameConsole;

internal class Program
{
    static IBiome Biome = new GrassLands();
    static GameMap GameMap = new GameMap(40, 30, Biome);
    static void Main(string[] args)
    {
        DrawMap(GameMap);
    }

    private static void DrawMap(GameMap mapToDraw)
    {
        Console.Clear();
        for (int x = 0; x < mapToDraw.Tiles.GetLength(0); x++)
        {
            for (int y = 0; y < mapToDraw.Tiles.GetLength(1); y++)
            {
                DrawTile(x, y);
            }

        }
    }

    private static void DrawTile(int x, int y)
    {
        var tileType = GameMap.Tiles[x, y];
        char displayCharacter = TileTypeToCharacterMap.Dictionary[tileType];

        Console.SetCursorPosition(x, y);
        Console.Write(displayCharacter);
    }
}
