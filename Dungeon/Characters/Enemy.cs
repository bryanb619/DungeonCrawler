using System;
using System.Collections.Generic;
using Dungeon.Items;

namespace Dungeon.Characters
{
    /// <summary>
    /// Abstract class representing an enemy in the game
    /// </summary>
    public  class Enemy : ICharacter
    {
        // Abstract property that represents enemy Health Points
        public int Hp { get; set; }


        // Abstract property that represents enemy Attack Power
        public  int AttackPower { get; }
        int ICharacter.AttackPower { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Attack(ICharacter target)
        {
            throw new NotImplementedException();
        }

        public void Heal(int amount)
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void PickUpItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(int amount)
        {
            throw new NotImplementedException();
        }
    }
}