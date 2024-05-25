using System;

namespace Dungeon.Items
{
    /// <summary>
    /// Represents Health Potion item
    /// </summary>
    public class HealthPotion : Item
    {


        // Read-only property
        public int Health { get; }

        /// <summary>
        /// Constructor for HealthPotion class
        /// Initializes Health property with the value passed as argument
        /// </summary>
        /// <param name="health">
        /// Value to be assigned to Health property (read-only)
        /// </param>
        public HealthPotion(string name, int health) : base (name)
        {
            Health = health;
        }


        public override int Use()
        {
            return Health;

        }
    }
}