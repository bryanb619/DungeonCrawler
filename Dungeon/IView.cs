using System;
using Dungeon.Items;
using System.Collections.Generic;

namespace Dungeon
{

    /// <summary>
    /// Interface
    /// </summary>
    public interface IView
    {
        

        void WelcomeMessage();

        int ShowMenu();

        int ShowInventory(List<Item> inventory);


        /// <summary>
        /// Interface method. The method to be invoked will be implemented in the
        /// View class.
        /// Should be used to display message string  passed as parameter.
        /// This method uses Console.WriteLine, so it will automaticaly enter a new 
        /// line after the string (message) in implemented class.
        /// No parameter can also be passed as the controller might just want a Enter.
        /// </summary>
        /// <param name="message">
        /// Message to be displayed (string)
        /// No parameters can also be passed just like using WriteLine(); without passing a parameter
        /// /// </param>
        void NewLineMessage(string message);


        /// <summary>
        /// Interface method.
        /// Should be used to display a int message passed as parameter.
        /// </summary>
        /// <param name="message">
        /// Message to be displayed (int)
        /// </param>
        void LineMessage(string message);


        string ReadInput();


        /// <summary>
        /// Interface Method.
        /// Should be used to wait for a key to be pressed.
        /// Like an event listener.
        /// </summary>
        void WaitForKey();


        /// <summary>
        /// Interface method.
        /// Should be used to display final message.
        /// </summary>
        void EndMessage();
        
        
    }
}