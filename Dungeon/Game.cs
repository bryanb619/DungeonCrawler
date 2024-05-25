using System;
using Dungeon.Characters;
using System.Collections.Generic;


namespace Dungeon
{
    public class Game
    {
        // Reference to the view Interface
        private  IView _view;

        // Reference to the model
        private Model _model;


        private Enemy Agent;

        private Player _player;

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
            _model.CreatePlayer();
            _player = _model.Player;

            view.WelcomeMessage();

         
            
            
            int option = 0;


            do

            {

                try
                {
                    option = _view.ShowMenu();


                    while(!correctNumber(option))
                    {
                        option = _view.ShowMenu();
                    }

                }

                catch (Exception e)
                {
                    _view.NewLineMessage(e.Message);
                }
            
                
    

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

                    default: 
                        _view.NewLineMessage("Invalid option\n");
                        break;
                        

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

                input.ToUpper();

                while(!correctDir(input))
                {
                    _view.LineMessage("Enter destination: ");
                    input = _view.ReadInput();
                }
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


                _view.NewLineMessage($"You moved {dir}");

                _view.WaitForKey();

                _view.NewLineMessage();

                _view.NewLineMessage(_model.NextRoomDescription());
            }

            // Call wrong passage message
            _view.WrongPassageChoice(); 
            
        }


        private void Attack()
        {
            Agent = _model.GetEnemy();
        

            if(Agent == null || Agent.Dead())
            {
                _view.NewLineMessage("No enemy to attack\n");
            }

            BattleLoop();
        }

        private void BattleLoop()
        {
            while (!Agent.Dead() || !_player.Dead())
            {

                if (_model.Turn % 2 == 0)
                {
                    string choice = "";
                    
                    _player.Attack(Agent);
                    _model.UpdateBattle(Agent);

                    if (Agent.SuccesfullAttack)
                    {
                        _view.NewLineMessage("You successfully hit"
                            +$" {_model.GetEnemyName()} with" 
                            +$" {choice} attack\nEnemy Hp: {_model.GetEnemyHp()}\n ");
                    }
                    
                    else
                    {
                        _view.NewLineMessage("Ups, you missed the attack...\n");
                    }
                }
                
                else
                {
                    Agent.Attack(_player);
                    _model.UpdateBattle(Agent);
                }
            }

        }


        private void GetItem()
        {

            _view.NewLineMessage("You used the chosen item");

            // ask model for items
            string pick = _model.GetItem();

            _view.NewLineMessage(pick);

            _view.NewLineMessage();
        }

        private bool correctDir(string dir)
        {
            // TODO : Add chars
            return dir == "A" || dir == "B" || dir == "C" || dir == "D";
        }


        private bool correctNumber(int number)
        {
            return number == 1 || number == 2 || number == 3 || number == 4;
        }

 
    }



    
}