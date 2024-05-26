using System.IO;
using System.Collections.Generic;
using Dungeon.Items;
using Dungeon.Characters;

namespace Dungeon
{
    public class Model
    {
        private Room[]  _room = new Room[16];

        private Player  _player;
        public Player   Player => _player;

        private int     CurrentRoom = 0;

        int a = 0;

        public int Turn {get; private set;} = 0;

        public void GenerateGame()
        {
            
            // Starting from left 
            CreateRoom("room0", new AttackPotion("Heretic Rage", 5), new Enemy("Titan", 50, 125) ,  0);

            CreateRoom("room1", null, null ,                                 1);

            CreateRoom("room2", new HealthPotion("God's tear",250), null ,   2);

            CreateRoom("room3", null, new Enemy("Traveler", 200, 15),        3);

            // going up!
            CreateRoom("room4", new HealthPotion("Ivy's Flask", -150), null, 4);

            // Top left corner room 
            CreateRoom("Room5", new HealthPotion("God's tear",250), null,    5);

            // left to right (Topw row)
            CreateRoom("Room6", null, new Enemy("Chaos", 250, 130),          6);

            CreateRoom("Room7", new AttackPotion("Heretic Rage", 5), null,   7);

            // bottom rows
            CreateRoom("Room8", new HealthPotion("Ivy's Flask", -150), null, 8);

            CreateRoom("Room9", new AttackPotion("Heretic Rage", 5), null,   9);

            CreateRoom("Room10", null, new Enemy("Armog", 350, 100),        10);

            CreateRoom("Room11",new HealthPotion("God's tear",250), null,   11);


            // center to right (middle )
            CreateRoom("Room12", null, new Enemy("Traveler", 200, 15), 12);

            CreateRoom("Room13", null, null, 13);

            CreateRoom("Room14", null, null, 14);

            CreateRoom("Room15", new HealthPotion("God's tear",250), 
            new Enemy("Titan", 500, 125), 15);

            CreateConnections();
        }

        private void CreateConnections()
        {
            // tile tou adicionar 
            _room[0].AddConnection(new Dictionary<string, Room> { 
                { "E", _room[1] } });


            _room[1].AddConnection(new Dictionary<string, Room> { 
                { "W", _room[0] }, 
                { "E", _room[2] }   
                 });


            _room[2].AddConnection(new Dictionary<string, Room> { 
                { "W", _room[1] },
                { "E", _room[3] }    
                });

            _room[3].AddConnection(new Dictionary<string, Room> { 
                { "W", _room[2] },
                { "E", _room[12] },
                { "N", _room[4]},
                { "S", _room[8] }
                });

            _room[4].AddConnection(new Dictionary<string, Room> { 
                { "W", _room[6] },
                {"E", _room[7]} });


            _room[5].AddConnection(new Dictionary<string, Room> { 
                { "E", _room[6] } });


            _room[6].AddConnection(new Dictionary<string, Room> { 
                { "W", _room[5] },
                { "E", _room[7]},
                { "N", _room[15]},
                { "S", _room[4]},  
                });

            _room[7].AddConnection(new Dictionary<string, Room> { 
                { "W", _room[6] },
                { "S", _room[4] }
                });
            

            _room[8].AddConnection(new Dictionary<string, Room> { 
                { "N", _room[3] },
                { "W", _room[9] },
                { "E", _room[10] }
                });

            _room[9].AddConnection(new Dictionary<string, Room> { 
                { "E", _room[8] } });


            _room[10].AddConnection(new Dictionary<string, Room> { 
                { "W", _room[8] },
                { "E", _room[15] },
                { "S", _room[11] }
                });


            _room[11].AddConnection(new Dictionary<string, Room> { 
                { "N", _room[10] } });


            _room[12].AddConnection(new Dictionary<string, Room> { 
                { "W", _room[3] },
                { "E", _room[13] },
                { "S", _room[14] }
                });

            _room[13].AddConnection(new Dictionary<string, Room> { 
                { "S", _room[14] },
                { "W", _room[12] },
                { "E", _room[15] }
                });

            _room[14].AddConnection(new Dictionary<string, Room> { 
                { "N", _room[13] },
                { "W", _room[12] },
                { "E", _room[15] }
                });


            _room[15].AddConnection(new Dictionary<string, Room> { 
                { "W", _room[13] },
                { "E", _room[14] },
                { "N", _room[6] },
                { "S", _room[10] }
                });
        }


        public void CreatePlayer()
        {
            _player = new Player();
        }



        private void TestRooms(
            string description, 
            Item item, 
            Enemy enemy, 
            int id)
        {

            _room[a] = new Room(description, item, enemy, id);
            a++;
        }


        private void ReadMap()
        {
            {
                using StreamReader sr = new StreamReader("Map/Map.txt");

                // line of file
                string line;

                // Room Loop index
                //int i = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    // read lines of file


                    // detect if line has Tab
                    if (line.Contains("\t"))
                    {
                        // add details to room
                        if (line.StartsWith("Description")) return;

                        if (line.StartsWith("Description")) return;
                   
                    }

                    else
                    {

                        // add room to list?
                        //_rooms.Add(new Room());

                        // increment index

                    }
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        /// <param name="exits"></param>
        /// <param name="item"></param>
        /// <param name="enemy"></param>
        private void CreateRoom(string description, Item item = null, 
            Enemy enemy = null, int id = 0)
        {

            _room[a] = new Room(description, item, enemy, id);
            a++;
        }


        // ------------- Action methods from controller ------------------------

        // attack

        /// <summary>
        /// 
        /// 
        /// </summary>
        public void UpdateBattle(Enemy Agent)
        {

            if (Turn % 2 == 0)
            {
                _player.Attack(Agent);
                Turn++;
            }
            else
            {
                Agent.Attack(Player);
                Turn++;
            }
        }

        public Enemy GetEnemy()
        {
            return _room[CurrentRoom].Enemy;
        }



        public string NextRoomDescription()
        {
           return _room[CurrentRoom].Description;
        }


        public string GetItem()
        {
    
            if (_room[CurrentRoom].Item != null)
            {

                Item item = _room[CurrentRoom].Item;

                string info = "";

                // player pick item
                _player.PickUpItem(item);


                if(IsItemHealth(item))
                {
                    HealthPotion healthPotion = (HealthPotion)item;

                    if(healthPotion.Health < 0)
                    {
                        info = $"{item.Name} removed {healthPotion.Health}" 
                        +$" of your health\nHp : {_player.Hp}";
                         
                    }

                    else
                    {
                        info = $"{item.Name} healed {healthPotion.Health}"
                        + $" of your health\nHp : {_player.Hp}";
                    }
                }

                else if (IsItemAttack(item))
                {
                    AttackPotion attackPotion = (AttackPotion)item;

                    info = $"{item.Name} increased your attack power by"
                    +$" {attackPotion.AttackPower}";
                       
                }

                // null this item
                _room[CurrentRoom].Item = null;


                return info;

            }
            
         

            return "Nothing here...";
        }

        public void DevMode()
        {
            
        }


        // ------------------ Data manipulation --------------------------------


        /*  Only section in Program where data is manipulated
            *  
            *

        */

        public bool CanMove(string input)
        {

            if (_room[CurrentRoom].Connections.ContainsKey(input))
            {

                Room nextRoom = _room[CurrentRoom].Connections[input];

                // update current room
                CurrentRoom = nextRoom.Id;
                
                // update player pos in world
                _player.UpdatePos(CurrentRoom);


                return true;
            }

            else
            {
                return false;
            }
        }


        private bool IsItemHealth(Item item)
        {
            return item.GetType() == typeof(HealthPotion);
        }

        private bool IsItemAttack(Item item)
        {
            return item.GetType() == typeof(AttackPotion);
        }

        public bool QuitGame()
        {
            return true;
        }
    }
}