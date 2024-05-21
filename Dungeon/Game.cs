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

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        public void Start(IView view)
        {
            
            _view = view;

            _model.GenerateGame();

            view.WelcomeMessage();

            view.ShowMenu();


            int option = 0;


            do

            {
                option = _view.ShowMenu();

                // Run the game loop
                // Get the player input

                // Update the model
                // Update the view
                // Check for game over

                switch (option)
                {
                    case 1:
                        Move();
                        break;

                    case 2:
                        _view.NewLineMessage("You attacked");
                        break;

                    case 3:
                        _view.NewLineMessage("You used an item");
                        break;

                    case 4:
                        _view.NewLineMessage("xxx");
                        break;

                    case 5: 
                        _view.NewLineMessage("xxx");
                        break;

                    case 6:
                        _view.NewLineMessage("You quit the game");

                        break;


                    default: { _view.NewLineMessage("Invalid option"); break;}

                }

            } while (option != 6);
        }



        /// <summary>
        /// 
        /// </summary>
        private void Move()
        {
            _view.LineMessage("Enter destination: ");

            string input = "";

            input = _view.ReadInput();


            if (_model.CanMove(input))
            {

                string dir = ""; 

                // TODO: add logic for saying where you moved to...

                switch(input)
                {
                    case "A":
                        dir = "North";
                        break;

                    case "E":

                        dir = "East";
                        break;

                    case "W":
                        dir = "West";
                        break;

                    case "S":
                        dir = "South";
                        break;

                    default: break;
                }

                _view.NewLineMessage($"You moved {dir}");

            }

            else { _view.NewLineMessage("You can't go there..."); }
            
        }

    }

    
}