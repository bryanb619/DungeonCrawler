using System;
using Dungeon.Items;
using System.Collections.Generic;

namespace Dungeon
{

    /// <summary>
    /// Interface where it has methods that print messages to show on the
    /// console in order to inform the player on the status of the game. These
    /// include information such as welcoming message, menu and combat status.
    /// </summary>
    public interface IView
    {
        
        /// <summary>
        /// Calls the method that prints a welcome message when the game starts.
        /// </summary>
        void WelcomeMessage();

        /// <summary>
        /// Calls the method that prints a the menu and it's options.
        /// </summary>
        /// <returns>Returns the option number inserted by the player</returns>
        int ShowMenu();

        int ShowInventory(List<Item> inventory);


        /// <summary>
        /// Interface method. The method to be invoked will be implemented in the
        /// View class.
        /// Should be used to display message string  passed as parameter.
        /// This method uses Console.WriteLine, so it will automaticaly enter a 
        /// new line after the string (message) in implemented class.
        /// No parameter can also be passed as the controller might just want a 
        /// Enter.
        /// </summary>
        /// <param name="message">
        /// Message to be displayed (string)
        /// No parameters can also be passed just like using WriteLine(); without passing a parameter
        /// /// </param>
        void NewLineMessage(string message ="");


        /// <summary>
        /// Prints a message to warn the player when he chooses a direction that
        /// is a wall and leads to no room.
        /// </summary>
        void WrongPassageChoice();


        /// <summary>
        /// Interface method.
        /// Should be used to display a int message passed as parameter.
        /// </summary>
        /// <param name="message">
        /// Message to be displayed (int)
        /// </param>
        void LineMessage(string message);


        /// <summary>
        /// Method that obtains a Console.Readline, a string introduced by the
        /// player.
        /// </summary>
        /// <returns>Returns the string inserted by the player</returns>
        string ReadInput();


        /// <summary>
        /// Interface Method.
        /// Should be used to wait for a key to be pressed.
        /// Like an event listener.
        /// </summary>
        void WaitForKey();

        /// <summary>
        /// Prints an error message for an unknown error.
        /// </summary>
        /// <param name="message"></param>
        void ErrorMessage(string message);


        /// <summary>
        /// Interface method.
        /// Should be used to display final message.
        /// </summary>
        void EndMessage();
        
        
    }
}