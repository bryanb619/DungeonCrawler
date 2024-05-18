using System;
using System.Collections.Generic;


namespace Dungeon
{
    public class Game
    {
        // Reference to the view Interface
        private  IView _view;

        // Reference to the model
        private Model _model;

        public Game(Model model)
        {
            _model = model;
        }


        public void Start(IView view)
        {

            _view = view;

            _model.GenerateGame();


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