using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon.Characters
{
    public class Player 
    {
        public int Health { get; set; }

        public int AttackPower { get ; set;}

        public Player()
        {
            Health = 10000;

        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void PickUpItem()
        {
            throw new NotImplementedException();
        }

        public void Attack()
        {
            throw new NotImplementedException();
        }
    }
}