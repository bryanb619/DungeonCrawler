using System;



namespace Dungeon
{
    public class View : IView
    {

        /// <summary>
        /// Displays final game message.
        /// No parameters are accepted.
        /// </summary>
        public void EndMessage()
        {
            Console.WriteLine("Game Over");
        }

        /// <summary>
        /// Received and displays a message of type string passed as a parameter.
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
        /// </summary>
        /// <param name="message">Message to be displayed (int)</param>
        public void DisplayMessage(int message)
        {
            Console.WriteLine(message);
        }


        
    }
}