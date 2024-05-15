using System;
using System.Collections.Generic;

namespace Dungeon.Characters
{
    /// <summary>
    /// Abstract class representing an enemy in the game
    /// </summary>
    public abstract class Enemy
    {
        // Abstract property that represents enemy Health Points
        public abstract int Hp { get; set; }


        // Abstract property that represents enemy Attack Power
        public abstract int AttackPower { get; }
    }
}