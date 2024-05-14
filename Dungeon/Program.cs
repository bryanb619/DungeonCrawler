using System;
using Dungeon.Items;

namespace Dungeon
{
    /// <summary>
    /// Represents the game entry point.
    /// 3 Instaces a created: Model, View and Controller
    /// Finaly the controller is run (Game loop)
    /// </summary>
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">Not used</param>
        private static void Main(string[] args)
        {

            // EXAMPLE of HealthPotion
            Item hp = new HealthPotion( 100 );

            if(hp is HealthPotion)
            {
                hp.Interact();
            }

            

            // Instantiate a model

            // Instantiate a view

            // Instantiate a controller


            // Run controller
        
        }
    }
}
