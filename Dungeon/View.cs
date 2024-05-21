using Dungeon.Items;
using System;
using System.Collections.Generic;

namespace Dungeon
{
    public class View : IView
    {
        private readonly Game _game;

        private readonly Model _model;  


        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        public View(Game game, Model model)
        {
            _game   = game;
            _model  = model;
        }


        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the dungeon!");
        }

        public int ShowMenu()
        {
            Console.WriteLine("1. Move");
            Console.WriteLine("2. Attack");
            Console.WriteLine("3. Use Item");
            Console.WriteLine("4. Quit");

            Console.Write("Choose an option: ");

    
            return Convert.ToInt32(Console.ReadLine());
          
        }


        public int ShowInventory(List<Item> inventory)
        {
            Console.WriteLine("Inventory: ");

            int i = 1;

            foreach (Item item in inventory)
            {
                Console.WriteLine($"{i}. {item.Name}");
                i++;
            }

            Console.Write("Choose an item: ");

            return Convert.ToInt32(Console.ReadLine());
        }



        /// <summary>
        /// Received and displays a message of type string passed as a parameter.
        /// Should be used to display messages like room description, player status, etc.
        /// This method uses Console.WriteLine, so it will automaticaly enter a new 
        /// line after the string (message)
        /// No parameter can also be passed as the controller might just want a Enter.
        /// </summary>
        /// <param name="message"> Message to be displayed (string) /// </param>
        public void NewLineMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Received and displays a message of type int passed as a parameter.
        /// int message is automatically converted to string by default using 
        /// Console.WriteLine class.
        /// Should be used to display messages like HP, Attack, etc.
        /// </summary>
        /// <param name="message">Message to be displayed (int)</param>
        public void LineMessage(string message)
        {
            Console.Write(message);
        }


        public string ReadInput()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Method Waits for a key to be pressed and continues the game cycle.
        /// </summary>
        public void WaitForKey()
        {
            Console.Write("\nPress any key to continue...");

            Console.ReadKey(true);

            Console.WriteLine("\n");
        }

        public void ErrorMessage(string message ="")
        {
            if (message.Length <= 0) Console.WriteLine("Unkown Error");

            Console.WriteLine(message);
            
        }

        /// <summary>
        /// Displays final game message.
        /// No parameters are accepted.
        /// </summary>
        public void EndMessage()
        {
            Console.WriteLine("Game Over");
        }


        
    }
}