using System;
using System.Collections.Generic;


namespace Dungeon.Items
{
    public class AttackPotion : Item
    {

        public int AttackPower { get; }

        public AttackPotion(string name, int damage) : base(name)
        {
            AttackPower = damage;
        }

        public override int Use()
        {
            return AttackPower;
        }
    }
}