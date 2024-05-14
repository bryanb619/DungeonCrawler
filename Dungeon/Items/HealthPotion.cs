using System;

namespace Dungeon.Items
{
    public class HealthPotion : Item
    {
        public int Health { get; private set; }


        public HealthPotion(int health)
        {
            Health = health;
        }

        public override void Interact()
        {
            Console.WriteLine("You drink the health potion and gain " + Health + " health.");
        } 
    }
}