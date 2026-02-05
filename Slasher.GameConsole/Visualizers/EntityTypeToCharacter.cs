using Slasher.GameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slasher.GameConsole.Visualizers;

public static class EntityTypeToCharacter
{
    public static Dictionary<EntityType, char> Dictionary = new() {
        { EntityType.Empty, ' '},
        { EntityType.Player, 'A'},
        { EntityType.Enemy, 'M'}
    };
}
