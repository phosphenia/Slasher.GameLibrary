using Slasher.GameConsole.Visualizers;
using Slasher.GameLibrary;
using Slasher.GameLibrary.Biomes;
using Slasher.GameLibrary.Interfaces;
using Slasher.GameLibrary.Enums;
using System.Security.Cryptography.X509Certificates;

namespace Slasher.GameConsole;

public class Program
{
    private static IBiome Biome = new GrassLands();
    private static GameMap GameMap = new GameMap(40, 30, Biome);
    private static int[] SpawnLocation = new int[2] { 20, 15 };
    private static Player Player = new();
    
    
    public static void Main(string[] args)
    {
        DrawMap(GameMap);
        DrawPlayer();

        ReadActionInput();
    }


    private static void DrawPlayer()
    {
        Player.DisplayCharacter = EntityTypeToCharacter.Dictionary[Player.EntityType];
        Player.Location = SpawnLocation;
        ReDrawPlayer(0, 0);
    }

    private static void ReDrawPlayer(int modX, int modY)
    {
        int[] modLocation = { Player.Location[0] + modX, Player.Location[1] + modY };

        if (modLocation[0] < GameMap.Tiles.GetLength(0) && modLocation[0] >= 0 && modLocation[1] < GameMap.Tiles.GetLength(1) && modLocation[1] >= 0)
        {
            DrawTile(Player.Location[0], Player.Location[1]);
            Player.Location = modLocation;
            Console.SetCursorPosition(Player.Location[0], Player.Location[1]);
            Console.Write(Player.DisplayCharacter);
            Console.SetCursorPosition(0, 30); 
        }
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
        int tileType = 0;

        if (GameMap.Tiles[x, y] is TileType t) { tileType = (int) t; }
        if (GameMap.Tiles[x, y] is GrowthTileType g) { tileType = (int) g; }

        char displayCharacter = TileTypeToCharacterMap.Dictionary[tileType];

        Console.SetCursorPosition(x, y);
        Console.Write(displayCharacter);
}
    private static void ReadActionInput()
    {
        ConsoleKey key;

        do
        {
            while (!Console.KeyAvailable)
            {
                //No key has been pressed yet
            }

            key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.W:
                    ReDrawPlayer(0, -1);
                    break;

                case ConsoleKey.S:
                    ReDrawPlayer(0, 1);
                    break;

                case ConsoleKey.A:
                    ReDrawPlayer(-1, 0);
                    break;

                case ConsoleKey.D:
                    ReDrawPlayer(1, 0);
                    break;
            }


        } while (key != ConsoleKey.Escape /* && player.IsAlive*/);
    }
}
