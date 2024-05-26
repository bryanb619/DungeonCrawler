using System;
using Dungeon.Characters;


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

        private bool quitGame = false;

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

            int option = 0;

            _view = view;
            view.WelcomeMessage();

            _model.GenerateGame();
            _model.CreatePlayer();
            _player = _model.Player;

        

            while (!quitGame)
            {

                if(_player.Dead()) break;

                if(Agent.Name == "Titan" && Agent.Dead()) break;

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
                        quitGame = _model.QuitGame();
                        _view.NewLineMessage(
                            "Wow, exiting the dungeon like this huh?");
                        break;

                    default: 
                        _view.NewLineMessage("Invalid option\n");
                        break;
                }
            } 
        }



        /// <summary>
        /// Method verifies if there's an enemy in the current room. If there is
        /// the player first has to defeat it. The direction where the player
        /// wants to move will be asked.
        /// </summary>
        private void Move()
        {

            Agent = _model.GetEnemy();

            _view.displayDirection();

            _view.LineMessage("Which direction do you want to go? ");




            string input = "";

            try
            {
                input = _view.ReadInput();

                //input.ToUpper();

                while(!correctDir(input))
                {
                    // Call wrong passage message
                    _view.WrongPassageChoice(); 

                    _view.LineMessage("Enter destination: ");
                    input = _view.ReadInput();
                }
            }


            catch (Exception e)
            {
                _view.ErrorMessage(e.Message);
            }


            if (_model.CanMove(input) && Agent == null || Agent.Dead())
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

            else{ _view.NewLineMessage("You must defeat your enemies...\n"); }
        }


        /// <summary>
        /// This method attacks the enemy that is in the room. If there's an 
        /// enemy, it will perform an attack turn on the enemy. A message will 
        /// warn the player saying there is no enemy in the room if that's the
        /// case.
        /// </summary>
        private void Attack()
        {
            Agent = _model.GetEnemy();
        

            if(Agent != null)
            {
                
                _view.NewLineMessage("You are attacking an enemy\n");

                BattleLoop();
            }

            else
            {
                _view.NewLineMessage("No enemy to attack\n");
            }
           
        }

        /// <summary>
        /// Method contains a while loop that continues until the player or the
        /// enemy is defeated. The player can choose between 3 different attacks
        /// </summary>
        private void BattleLoop()
        {


            while (!Agent.Dead())
            {
                string choice = "";
                int attackChoice;


                if(_player.Dead())
                {
                    _view.NewLineMessage($"You were defeated by {Agent.Name}\n");
                    break;
                }

                if(Agent.Name == "Titan" && Agent.Dead())
                {   
                   
                    _view.NewLineMessage("Wow, you have defeated the Titan\n");
                    quitGame = _model.QuitGame();
                    break;
                } 

              
                else
                {
                
                    if (_model.Turn % 2 == 0)
                    {   

                    

                        _view.NewLineMessage("--- Your turn ---\n");

                        _view.NewLineMessage("Options are:\n"
                            +"1.Heavy Sword attack\t2. Normal attack\t3. Bow Attack");
                        
                        _view.LineMessage("Option :");

                        attackChoice = int.Parse(_view.ReadInput());
        
                        
                        switch(attackChoice)
                        {
                            case 1:
                                choice = "Heavy Sword";
                                break;

                            case 2:
                                choice = "Normal";
                                break;

                            case 3: 
                                choice = "Bow";
                                break;

                            case 4:
                                _view.NewLineMessage("DEBUG KILL PLAYER");
                                _player.Hp = 0;
                                break;

                            default : break;
                        }

                        if (Agent.SuccesfullAttack)
                        {
                            _view.NewLineMessage("You successfully hit"
                                +$" {Agent.Name} with" 
                                +$" {choice} attack\nEnemy Hp: {Agent.Hp}\n ");
                        }

                        else if(!Agent.SuccesfullAttack)
                        {
                            _view.NewLineMessage("Ups, you missed the attack...\n");

                            
                        }

                        _model.UpdateBattle(Agent);
                        
                    }

                    else
                    {

                        _view.NewLineMessage("--- Enemy turn ---\n");

                        Agent.Attack(_player);

                        if(Agent.PlayerSuccessAttack)
                        {
                            _view.NewLineMessage($"{Agent.Name} attacked you\n"
                            +$"Your Hp: {_player.Hp}\n");
                        }
                        else if(!Agent.PlayerSuccessAttack)
                        {
                            _view.NewLineMessage("Lucky you!" 
                            +$" {Agent.Name} missed the attack\n");
                        }
                    
                    
                        _model.UpdateBattle(Agent);
                    }
                }
        
            }

            if(Agent.Dead())
            {
                _view.NewLineMessage($"You defeated {Agent.Name}\n");
            }

            else if(_player.Dead())
            {
            
                _model.QuitGame();
            }
        }


        /// <summary>
        /// Method prints a message to inform the player the use of the chosen
        /// item.
        /// </summary>
        private void GetItem()
        {

            _view.NewLineMessage("You used the chosen item");

            // ask model for items
            string pick = _model.GetItem();

            _view.NewLineMessage(pick +"\n");
            
        }

        /// <summary>
        /// Method associates and links the chars inserted to the direction that
        /// the player wants to move (N: North; E: East, W: West, S: South)
        /// </summary>
        /// <param name="dir"></param>
        /// <returns>Returns the char that corresponds to a direction</returns>
        private bool correctDir(string dir)
        {
            // TODO : Add chars
            return dir == "N" || dir == "E" || dir == "W" || dir == "S";
        }


        /// <summary>
        /// Method associates a number with the direction selected (N = 1; 
        /// E = 2; W = 3; S = 4)
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Returns the int that corresponds to a direction</returns>
        private bool correctNumber(int number)
        {
            return number == 1 || number == 2 || number == 3 || number == 4;
        }
    }
}