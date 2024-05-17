using System;

namespace Dungeon
{
    public class View : IView
    {
        private readonly Game _game;

        // TODO: Add Model reference
        // private readonly


        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        public View(Game game, Room room)
        {
            _game = game;
            // _model = model;
        }


        /// <summary>
        /// Received and displays a message of type string passed as a parameter.
        /// Should be used to display messages like room description, player status, etc.
        /// </summary>
        /// <param name="message"> Message to be displayed (string) /// </param>
        public void DisplayMessage(string message)
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
        public void DisplayMessage(int message)
        {
            Console.WriteLine(message);
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