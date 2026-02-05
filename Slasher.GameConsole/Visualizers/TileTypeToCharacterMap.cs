using Slasher.GameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slasher.GameConsole.Visualizers;

public static class TileTypeToCharacterMap
{
    public static Dictionary<Enum, char> Dictionary = new Dictionary<Enum, char>() {
        { (Enum) TileType.Empty, ' '},
        { (Enum) TileType.Grass, '.'},
        { (Enum) TileType.Water, '-'},
        { (Enum) TileType.Rock, '*'}};
}
