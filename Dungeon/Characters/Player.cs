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
                if(_hp <= 0)
                {  
                    // kill 
                }

                _hp -= value;
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


        // inventory list
        private List<Item> _inventory = new List<Item>(10);

        public List<Item> Inventory => _inventory;



        /// <summary>
        /// Constructor for the Traveler Enemy
        /// </summary>
        public Player(string name = "Player")
        {
            Name            = name;
            Hp              = 10000;
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
            _inventory.Add(item);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void UseInventoryItem(Item item)
        {

            if(item.GetType() == typeof(HealthPotion))
            {
                Hp += item.Use();
            }
            // other potion

            // other potion2
            
            _inventory.Remove(item);
        }

        public void UpdatePos(int pos)
        {
            // TODO: Implement movement
            this.PlayerPos = pos;
            
        }

        public void Heal(int amount)
        {
            Hp += amount;
        }

        public void TakeDamage(int amount)
        {
            Hp -= amount;
        }

    }
}