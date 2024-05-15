using System;
using System.Collections.Generic;

namespace Dungeon.Characters
{
    public class Traveler : Enemy
    {
        /// <summary>
        /// Hp property for the Traveler enemy
        /// 
        /// </summary>
        /// <value>
        /// Passed value will be subtracted from the current agent Hp 
        /// Use of the property without setting a value will return the current Hp value of Traveler agent
        /// </value>
        public override int Hp 
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
        public override int AttackPower { get; } = 50;


        /// <summary>
        /// Constructor for the Traveler Enemy
        /// </summary>
        public Traveler()
        {
            Hp = 100;

        }
        
    }
}