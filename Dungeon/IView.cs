using System;
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


        /// <summary>
        /// Interface method.
        /// Should be used to display a string message passed as parameter.
        /// </summary>
        /// <param name="message">
        /// Message to be displayed (string)
        /// /// </param>
        void DisplayMessage(string message);


        /// <summary>
        /// Interface method.
        /// Should be used to display a int message passed as parameter.
        /// </summary>
        /// <param name="message">
        /// Message to be displayed (int)
        /// </param>
        void DisplayMessage(int message);


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