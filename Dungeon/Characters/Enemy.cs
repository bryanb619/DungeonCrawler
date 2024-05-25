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
        public string Name { get; }

        // Abstract property that represents enemy Health Points
        public int Hp { get; set; }

        // Abstract property that represents enemy Attack Power
        public int AttackPower { get; set; }


        public bool SuccesfullAttack { get; private set; } 
        
        public Enemy(string name, int hp, int attackPower)
        {
            Name        = name;
            Hp          = hp;
            AttackPower = attackPower;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public void Attack(ICharacter target)
        {
            target.TakeDamage(AttackPower);
        }

        public void Heal(int amount)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        public void TakeDamage(int amount)
        {
            Random rand = new Random();

            int chanceOfSuccess = rand.Next(0, 10);


            if (chanceOfSuccess >= 4) 
            { 
                this.Hp -= amount;
                SuccesfullAttack = true;

            }
            
            else
            {
                SuccesfullAttack = false;
                Console.WriteLine(SuccesfullAttack );
            }

        }


        public bool Dead()
        {
            return Hp >= 0;
        }
    }
}