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

            
           

            DebugRoom();

          


            // Instantiate a game   (controller) 
            //Game game = new Game();

            // Instantiate a view 
            // pass as param (game, room) 
            //IView view = new View(game, room);
            
            // Run the game         
            //game.Start(view);


        }


        private static void DebugRoom()
        {
            Room[] room = new Room[15];


            string description = "You are in a dark room";


            Dictionary<string, Room> exits = new Dictionary<string, Room>
            {
                { "N", room[1] }

            };

            Item item = new HealthPotion(100);

            Enemy enemy = new Enemy("Chaos", 100, 100);


            room[0]  = new Room(description, exits, item , enemy);


            Console.WriteLine($" Description: {room[0].Description}");
            Console.WriteLine($" Conections: {room[0].Connections.Values.ToString()}");
            Console.WriteLine($" Item: {room[0].Item.Name}");
            Console.WriteLine($" Enemy: {room[0].Enemy.Name}");
        }

    }
}
