using Slasher.GameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slasher.GameLibrary
{
    public class Player : Entity
    {
        public Player()
        {
            EntityType = EntityType.Player;
            SpawnLocation = new int[2] { 20, 15 };
        }
    }
}
