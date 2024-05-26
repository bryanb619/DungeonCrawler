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


        /// <summary>
        /// Prints on the screen the welcome message to the player, introducing
        /// the name of the game, the setting where the player is and how the
        /// player intends to proceed.
        /// </summary>
        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Yet Another Dungeon Crawler!");
            Console.WriteLine(
                "You have entered a Dungeon of... Another Dungeon Crawler.");
            Console.WriteLine(
                "Since you're here, how would you like to proceed?");
        }

        /// <summary>
        /// Prints on the screen the menu of the game: 1. Player can choose 
        /// where to move; 2: Player can attack the enemy; 3: Player can access
        /// inventory to use an item; 4: Player can quit the game as it will
        /// close.
        /// </summary>
        /// <returns>
        /// Returns an int that will be used to access the chosen option
        /// </returns>
        public int ShowMenu()
        {
            Console.WriteLine("1. Move");
            Console.WriteLine("2. Attack");
            Console.WriteLine("3. Use Item");
            Console.WriteLine("4. Quit Game");
            Console.WriteLine("5. Dev Mode");

            Console.Write("Choose your next action: ");

    
            return Convert.ToInt32(Console.ReadLine());
          
        }

        /// <summary>
        /// Received and displays a message of type string passed as a parameter.
        /// Should be used to display messages like room description, player 
        /// status, etc.
        /// This method uses Console.WriteLine, so it will automatically enter a
        /// new line after the string (message)
        /// No parameter can also be passed as the controller might just want a 
        /// Enter.
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

        /// <summary>
        /// Prints the possible directions that the player can choose: North, 
        /// South, West and East.
        /// </summary>
        public void displayDirection()
        {
            Console.WriteLine("Directions: N. North, E. East, S. South, W. West");
        }


        /// <summary>
        /// Method that obtains a Console.Readline, a string introduced by the
        /// player.
        /// </summary>
        /// <returns>Returns the string inserted by the player</returns>
        public string ReadInput()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Method Waits for a key to be pressed and continues the game cycle.
        /// </summary>
        public void WaitForKey()
        {
            Console.Write("\n** Gently smash any key to proceed **");

            Console.ReadKey(true);

            Console.WriteLine("\n");
        }

        /// <summary>
        /// Prints a message to indicate the player that he choose a path that
        /// leads to a wall, asking the player to choose another direction.
        /// </summary>
        public void WrongPassageChoice()
        {
            Console.WriteLine("Ability to cross walls only in DLC version."
            +" Choose a direction with a door");
        }

        /// <summary>
        /// Method displays a general Error Message
        /// </summary>
        /// <param name="message"></param>
        public void ErrorMessage(string message ="")
        {
            if (message.Length <= 0) Console.WriteLine("Unknown Error");

            Console.WriteLine(message);
            
        }

        /// <summary>
        /// Displays final game message.
        /// No parameters are accepted.
        /// </summary>
        public void EndMessage()
        {
            Console.WriteLine(
                "You're not very good at dungeon crawling are you...");
        }

        public int ShowInventory(List<Item> inventory)
        {
            throw new NotImplementedException();
        }

        public int DevOption()
        {   
            Console.WriteLine("---- Debug ----\n");
            Console.WriteLine("Dev Options");
            Console.WriteLine("1. Heal Player: 100Hp");
            Console.WriteLine("2. Kill enemy");
            Console.WriteLine("3. Kill Player");
            Console.WriteLine("4. Skip to Boss Room");
            Console.Write("Choose your option: ");

            return int.Parse(Console.ReadLine());
        }
    }
}