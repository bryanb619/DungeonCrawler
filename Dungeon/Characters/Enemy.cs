using System;

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

        public bool PlayerSuccessAttack { get; private set; } 
        
        public Enemy(string name, int hp, int attackPower)
        {
            Name        = name;
            Hp          = hp;
            AttackPower = attackPower;
        }

        /// <summary>
        /// Accepts an ICharacter object as a parameter and attacks it 
        /// </summary>
        /// <param name="target"></param>
        public void Attack(ICharacter target)
        {
            if (RandValue() >= 6) 
            { 
                target.TakeDamage(AttackPower);
                PlayerSuccessAttack = true;
            }
                
            else
            {
                PlayerSuccessAttack = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        public void TakeDamage(int amount)
        {

            if (RandValue() >= 1) 
            { 
                Hp -= amount;
                SuccesfullAttack = true;

            }
            
            else
            {
                SuccesfullAttack = false;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int RandValue()
        {
            Random rand = new Random();

            return rand.Next(0, 10);
        }


        public bool Dead()
        {
            return Hp <= 0;
        }
    }
}