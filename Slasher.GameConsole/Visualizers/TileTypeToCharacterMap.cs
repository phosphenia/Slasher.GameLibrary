using Slasher.GameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slasher.GameConsole.Visualizers;

public static class TileTypeToCharacterMap
{
    public static Dictionary<TileType, char> Dictionary = new () {
        { TileType.Empty , ' '},
        { TileType.Grass , '.'},
        { TileType.Water, '~'},
        { TileType.Rock, '*'}};
}
