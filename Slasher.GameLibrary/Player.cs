using Slasher.GameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Slasher.GameLibrary;

public class Player : Entity
{
    public bool UpdateInfo { get; set; }
    public int HealthPointRollOver { get; } = 10;

    public Player()
    {
        EntityType = EntityType.Player;
        SpawnLocation = new int[2] { 20, 15 };
        HealthPoints = 45;
    }
}
