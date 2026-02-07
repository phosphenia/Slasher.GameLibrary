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
    private static Player Player = new();

    //TODO replace {Enemy Enemy} with {Enemy[] Enemies}.
    private static Enemy Enemy = new();
    
    
    public static void Main(string[] args)
    {
        DrawMap(GameMap);
        DrawEntity(Player);
        //TODO implement enemy-spawning system.
        DrawEntity(Enemy);

        ReadActionInput();
    }


    private static void DrawEntity(Entity subject)
    {
        subject.DisplayCharacter = EntityTypeToCharacter.Dictionary[subject.EntityType];
        subject.Location = subject.SpawnLocation;
        ReDrawEntity(subject, 0, 0);
    }

    private static void ReDrawEntity(Entity subject, int modX, int modY)
    {
        int[] modLocation = { subject.Location[0] + modX, subject.Location[1] + modY };

        if (modLocation[0] < GameMap.Tiles.GetLength(0) && modLocation[0] >= 0 && modLocation[1] < GameMap.Tiles.GetLength(1) && modLocation[1] >= 0)
        {
            DrawTile(subject.Location[0], subject.Location[1]);
            subject.Location = modLocation;
            Console.SetCursorPosition(subject.Location[0], subject.Location[1]);
            Console.Write(subject.DisplayCharacter);
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
                    ReDrawEntity(Player, 0, -1);
                    break;

                case ConsoleKey.S:
                    ReDrawEntity(Player, 0, 1);
                    break;

                case ConsoleKey.A:
                    ReDrawEntity(Player, -1, 0);
                    break;

                case ConsoleKey.D:
                    ReDrawEntity(Player, 1, 0);
                    break;
            }
            AdvanceTick();


        } while (key != ConsoleKey.Escape /* && player.IsAlive*/);
    }

    private static void AdvanceTick()
    {
        //Temp Enemy AdvanceTick logic.

        int[] movementVector = Enemy.AdvanceTick(Player.Location);
        ReDrawEntity(Enemy, movementVector[0], movementVector[1]);
        Console.WriteLine($"Lortet virker sgu {Player.Location[0]} {Player.Location[1]} {movementVector[0]} {movementVector[1]} ");

        //Enemy[] AdvanceTick logic.
        /*int[] movementVector = new int[2];
        foreach (Enemy item in Enemies)
        {
            movementVector = item.AdvanceTick(Player.Location);
            ReDrawEntity(item, movementVector[0], movementVector[1]);
        }*/
    }
}
