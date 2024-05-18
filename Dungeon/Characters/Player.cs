using System;
using System.Collections.Generic;
using Dungeon.Items;

namespace Dungeon.Characters
{
    public class Player : ICharacter
    {
       /// <summary>
        /// Hp property for the Player enemy
        /// 
        /// </summary>
        /// <value>
        /// Passed value will be subtracted from the current agent Hp 
        /// Use of the property without setting a value will return the current Hp value of Traveler agent
        /// </value>
        public  int Hp 
        { 
            get { return Hp; }

            set 
            {
                // Check if the value is less than 1

                if (Hp < 1)
                {

                    // Kill this agent
                    // break 
                }

                this.Hp -= value;
            }
         }

        /// <summary>
        /// AttackPower property for the Traveler enemy
        /// Read-only property set to 50 by default
        /// </summary>
        /// <value></value>
        public int AttackPower { get ; set; }


        public string Name { get; }


        /// <summary>
        /// Constructor for the Traveler Enemy
        /// </summary>
        public Player(string name)
        {
            Name = name;
            Hp = 10000;
            AttackPower = 50;

        }

        public void Attack(ICharacter target)
        {

            if(target != null)
            {   
                target.TakeDamage(AttackPower);
            }
           
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Heal(int amount)
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(int amount)
        {
            throw new NotImplementedException();
        }

        public void PickUpItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}