using System;
using System.IO;
using System.Collections.Generic;
using Dungeon.Items;
using Dungeon.Characters;
using System.Security.Cryptography.X509Certificates;

namespace Dungeon
{
    public class Model
    {

        private Room[]  _room = new Room[15];


        private Player  _player;
        public Player Player => _player;

        private int     CurrentRoom = 0;

        int a = 0;

        public int Turn {get; private set;} = 0;

        public void GenerateGame()
        {
            
            TestRooms("A dark Room", new HealthPotion("Ivy's Flask", -150), new Enemy("Chaos", 250, 135),0);
            TestRooms("room1", new HealthPotion("God's tear",250), new Enemy("Chaos", 100, 10),1);
            TestRooms("room2", new HealthPotion("God's tear",250), new Enemy("Titan", 200, 15),2);
            TestRooms("Room3", new HealthPotion("God's tear",250), new Enemy("Chaos", 100, 10),3);
            TestRooms("Room3", new HealthPotion("God's tear",250), new Enemy("Chaos", 100, 10),4);

        

            _room[0].AddConnection(new Dictionary<string, Room> { 
                { "E", _room[1] } });


            _room[1].AddConnection(new Dictionary<string, Room> { 
                { "W", _room[0] }, 
                { "E", _room[2] }    });


            _room[2].AddConnection(new Dictionary<string, Room> { 
                { "W", _room[1] },
                { "E", _room[3] }    });

            _room[3].AddConnection(new Dictionary<string, Room> { 
                { "W", _room[2] },
                {"N", _room[4]}    });


            foreach (Room room in _room)
            {
                //Console.WriteLine(room.Connections);
            }
        }



        public void CreatePlayer(string name = "Player")
        {
            _player = new Player(name);
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
        private void CreateRooms(string description, Item item = null, 
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

            
        public bool GameOver()
        {
            return true;//_player.Hp <= 0;
        }

    

    }
}