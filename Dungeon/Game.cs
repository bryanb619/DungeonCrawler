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
        /// <param name="view">
        /// Receives IView inteface as parameter.
        /// Essencial reference so the Controller (Game.cs) can comunicate with 
        /// the 
        /// </param>
        public void Start(IView view)
        {
            
            _view = view;

            _model.GenerateGame();

            view.WelcomeMessage();
            
            _model.CreatePlayer();


            int option = 0;


            do

            {

      
            
                option = _view.ShowMenu();

                while(option != 1)
    

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
                        Attack();
                        break;

                    case 3:
                        GetItem();
                        break;

                    case 4:
                        _view.NewLineMessage(
                            "Wow, exiting the dungeon like this huh?");
                        break;


                    case 5:
                        _view.NewLineMessage("other action");
                        break;

                    case 6: 
                        _view.NewLineMessage("other action 2");
                        break;


                    default: 
                        {
                            _view.NewLineMessage("Invalid option");

                            // New Line
                            _view.NewLineMessage();
                            break;
                        }

                }

            } while (option != 4);
        }



        /// <summary>
        /// 
        /// </summary>
        private void Move()
        {
            _view.LineMessage("Which direction do you want to go? ");


            string input = "";


            try
            {
                input = _view.ReadInput();
            }


            catch (Exception e)
            {
                _view.ErrorMessage(e.Message);
            }


    

            if (_model.CanMove(input))
            {

                string dir = ""; 

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


                _view.WaitForKey();

                _view.NewLineMessage($"You moved {dir}");

                _view.NewLineMessage(_model.NextRoomDescription());
            }

            else { _view.NewLineMessage(
                "Ability to cross walls only in DLC version. Choose a direction with a door"); }
            
        }


        /// <summary>
        /// 
        /// </summary>
        private void NewRoom()
        {
            

        }


        private void Attack()
        {
            _view.NewLineMessage("You successfully hit your enemy");
        }


        private void GetItem()
        {
            _view.NewLineMessage("You used the chosen item");

            // ask model for items

            
        }

    }



    
}