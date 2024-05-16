using System;
using System.Collections.Generic;


namespace Dungeon
{
    public class Game
    {
        // Reference to the view Interface
        private  IView _view;


        public void Start(IView view)
        {

            _view = view;


            view.DisplayMessage("Welcome to the dungeon!");

            /*
            while(true)
            {
                // Run the game loop
                // Get the player input
                // Update the model
                // Update the view
                // Check for game over
            }
            */
            
        }
        
    }

    
}