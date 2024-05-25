using System;
using System.Collections.Generic;
using Dungeon.Items;

namespace Dungeon.Characters
{
    public class Player : ICharacter
    {


        private int Max_Hp = 1000;

        /// <summary>
        /// Hp property for the Player
        /// 
        /// </summary>
        /// <value>
        /// Passed value will be subtracted from the current agent Hp 
        /// Use of the property without setting a value will return the current Hp value of Traveler agent
        /// </value>
        public int Hp {

            get;

            set;

        }

        /// <summary>
        /// AttackPower property for the Traveler enemy
        /// Read-only property set to 50 by default
        /// </summary>
        /// <value></value>
        public int AttackPower { get ; set; }

        public int PlayerPos { get; private set; } = 0;


        /// <summary>
        /// Constructor for the Traveler Enemy
        /// </summary>
        public Player()
        {
            Hp              = Max_Hp;
            AttackPower     = 85;
        }

        public void Attack(ICharacter target)
        {
            target.TakeDamage(AttackPower);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void PickUpItem(Item item)
        {

            if(item.GetType() == typeof(HealthPotion))
            {
                
                HealthPotion healthPotion = (HealthPotion)item;

                Heal(healthPotion.Health);
            }

            else if(item.GetType() == typeof(AttackPotion))
            {
                AttackPotion attackPotion = (AttackPotion)item;

                AttackPower += attackPotion.AttackPower;
            }
                
        }
    

        public void UpdatePos(int pos)
        {
            // TODO: Implement movement
            this.PlayerPos = pos;
            
        }


        public void Heal(int amount)
        {
            if (Hp + amount > Max_Hp) Hp = Max_Hp;

            else Hp += amount;
        }

        public void TakeDamage(int amount)
        {
            
            Hp -= amount;

        }

        public bool Dead()
        {
            return Hp <= 0; 
        }

    }
}