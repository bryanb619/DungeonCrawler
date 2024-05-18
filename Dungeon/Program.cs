using System;
using System.Collections.Generic;
using Dungeon.Items;
using Dungeon.Characters;

namespace Dungeon
{
    /// <summary>
    /// Represents the game entry point.
    /// 3 Instaces a created: Model, View and Controller
    /// Finaly the controller is run (Game loop)
    /// </summary>
    class Program
    {
        // DEBUG ROOM
        private static Room[] room = new Room[15];

        /// <summary>
        /// Entry point of the game.
        /// 3 instances are created: Model, Controller and View.
        /// Model       = Room class => represents Program logic. 
        /// Controller  = Game class => represents the game loop.
        /// View        = View class => represents the user interface (UI).
        /// </summary>
        /// <param name="args">Not used</param>
        private static void Main(string[] args)
        {

            // Instantiate a room   (model)
            Model model = new Model();

    
            // Instantiate a game   (controller) 
            Game game = new Game(model);

            // Instantiate a view 
            //pass as param (game, model) 
            IView view = new View(game, model);
            
            // Run the game         
            game.Start(view);


        }

    }
}
