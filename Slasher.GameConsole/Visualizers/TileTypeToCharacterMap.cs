using Slasher.GameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slasher.GameConsole.Visualizers;

public static class TileTypeToCharacterMap
{
    public static Dictionary<int, char> Dictionary = new () {
        { (int) TileType.Empty, ' '},
        { (int) TileType.Grass, '.'},
        { (int) TileType.Water, '~'},
        { (int) TileType.Rock, '*'}};
}
