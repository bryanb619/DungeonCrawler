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
            //Player class

            // EXAMPLE of HealthPotion
            Item hp = new HealthPotion(100);

            if(hp is HealthPotion)
            {
                hp.Interact();

                

                // player instance.Health += hp.Value

                // para cada sala pode existir (no jogador uma lista que é auto limpa a cada saída de sala)
                
                
                // Loop de ações ou combate
            }

            /*


            */

            

            // Instantiate a model

            // Instantiate a view

            // Instantiate a controller


            // Run controller
        
        }
    }
}
