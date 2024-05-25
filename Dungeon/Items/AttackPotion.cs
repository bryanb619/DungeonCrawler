using System;
using System.Collections.Generic;


namespace Dungeon.Items
{
    public class AttackPotion : Item
    {
        public AttackPotion(string name) : base(name)
        {
        }

        public override void Interact()
        {
            throw new NotImplementedException();
        }

        public override int Use()
        {
            throw new NotImplementedException();
        }
    }
}