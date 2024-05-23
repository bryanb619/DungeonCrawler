using System;
using System.Collections.Generic;
using Dungeon.Items;

namespace Dungeon.Characters
{
    public class Player : ICharacter
    {


        private int _hp; 

        /// <summary>
        /// Hp property for the Player
        /// 
        /// </summary>
        /// <value>
        /// Passed value will be subtracted from the current agent Hp 
        /// Use of the property without setting a value will return the current Hp value of Traveler agent
        /// </value>
        public int Hp {

            get { return _hp; }


            set { 
               
                _hp += value;
            }

          
        }

        /// <summary>
        /// AttackPower property for the Traveler enemy
        /// Read-only property set to 50 by default
        /// </summary>
        /// <value></value>
        public int AttackPower { get ; set; }

        public string Name { get; }

        public int PlayerPos { get; private set; } = 0;


        /// <summary>
        /// Constructor for the Traveler Enemy
        /// </summary>
        public Player(string name = "Player")
        {
            Name            = name;
            _hp              = 10000;
            AttackPower     = 85;
        }

        public void Attack(ICharacter target)
        {

            if(target != null)
            {   
                target.TakeDamage(AttackPower);
            }
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


                Console.WriteLine(Hp);

            }
                
        }
    

        public void UpdatePos(int pos)
        {
            // TODO: Implement movement
            this.PlayerPos = pos;
            
        }


        public void Heal(int amount)
        {
            _hp += amount;
        }

        public void TakeDamage(int amount)
        {
            Hp -= amount;
        }

    }
}