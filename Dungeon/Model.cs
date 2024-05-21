using System;
using System.IO;
using System.Collections.Generic;
using Dungeon.Items;
using Dungeon.Characters;

namespace Dungeon
{
    public class Model
    {

        private Room[]  _room = new Room[15];

        private Player  _player;

        private int     CurrentRoom = 0;

        int a = 0;

        public void GenerateGame()
        {
            
            TestRooms("A dark Room", new HealthPotion(), new Enemy("Chaos", 100, 10),0);
            TestRooms("room1", new HealthPotion(), new Enemy("Chaos", 100, 10),1);
            TestRooms("room2", new HealthPotion(), new Enemy("Titan", 200, 15),2);
            TestRooms("Room3", new HealthPotion(), new Enemy("Chaos", 100, 10),3);
            TestRooms("Room3", new HealthPotion(), new Enemy("Chaos", 100, 10),4);

        

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



            
            CreatePlayer();

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
            string description = "some room", 
            Item item = null, 
            Enemy enemy = null, 
            int i = 0)
        {

            _room[a] = new Room(description, item, enemy, i);
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
        private void CreateRooms(string description, Item item, Enemy enemy)
        {

    
        }


        // ------------- Action methods from controller ------------------------

        public string NextRoomDescription()
        {
           return _room[CurrentRoom].Description;
        }


        public void PickItem()
        {
            // add item to player inventory
            _player.PickUpItem(_room[CurrentRoom].Item);

            // null this item
            _room[CurrentRoom].Item = null;
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

            return false;
        }

            
        public bool GameOver()
        {
            return _player.Hp <= 0;
        }

    

    }
}