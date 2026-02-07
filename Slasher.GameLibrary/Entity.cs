using Slasher.GameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slasher.GameLibrary
{
    public abstract class Entity
    {
        public string Name { get; set; }
        public EntityType EntityType { get; set; }
        public int[] SpawnLocation { get; set; }
        public int[] Location { get; set; }
        public char DisplayCharacter { get; set; }
    }
}
