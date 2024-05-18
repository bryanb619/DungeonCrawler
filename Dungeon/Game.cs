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


            

            //if (_model.canMove("E")) view.DisplayMessage("You moved East");

            //else view.DisplayMessage("You can't move there");


            view.WelcomeMessage();

            view.ShowMenu();


            while(true)
            {
                int option = _view.ShowMenu();


                switch(option)
                {
                    case 1:
                        Move();
                        break;
                    case 2:
                        _view.DisplayMessage("You attacked");
                        break;
                    case 3:
                        _view.DisplayMessage("You used an item");
                        break;
                    case 4:
                        _view.DisplayMessage("You quit the game");
                        break;
                    default:
                        _view.DisplayMessage("Invalid option");
                        break;
                }
                
                // Run the game loop
                // Get the player input
               
                // Update the model
                // Update the view
                // Check for game over
            }
            
        }


        private void Move()
        {
            string input = "";

            if( _model.canMove(input))
            {
                // TODO: add logic for saying where you moved to...
                _view.DisplayMessage(input);

            } 

            else _view.DisplayMessage("You can't go there...");
            
        }

    }

    
}