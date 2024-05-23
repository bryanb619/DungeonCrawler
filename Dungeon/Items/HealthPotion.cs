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
        public HealthPotion(string name, int health = 250) : base (name)
        {
            Health = health;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Interact()
        {
            // TODO: Remove Console.WriteLine from this class as it violates MVC pattern
            // TODO: Link with player class and increase player health
            Console.WriteLine("You drink the health potion and gain " + Health + " health.");
        }

        public override int Use()
        {
            return Health;

        }
    }
}