using Slasher.GameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slasher.GameLibrary
{
    public class Player
    {
        public string Name { get; } = "Oliver";
        public EntityType EntityType { get; } = EntityType.Player;
        public int[] Location { get; set; }
        public char DisplayCharacter { get; set; }
    }
}
