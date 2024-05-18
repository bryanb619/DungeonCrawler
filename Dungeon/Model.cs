using System;
using System.IO;
using System.Collections.Generic;
using Dungeon.Items;
using Dungeon.Characters;

namespace Dungeon
{
    public class Model
    {

        private Room[] _room = new Room[15];

        public Room[] Room { get; private set; }


        private int playerPos = 0;

        int a = 0;


        public void GenerateGame()
        {
            
            TestRooms("A dark Room", new HealthPotion(), new Enemy("Chaos", 100, 10));
            TestRooms("room1", new HealthPotion(), new Enemy("Chaos", 100, 10));
            TestRooms("room2", new HealthPotion(), new Enemy("Titan", 200, 15));
            TestRooms("Room3", new HealthPotion(), new Enemy("Chaos", 100, 10));
            
            Room = _room;


            Dictionary<string, Room> exits = new Dictionary<string, Room>
            {
                { "E", Room[1] }
            };

            Dictionary<string, Room> exits2 = new Dictionary<string, Room>
            {
                { "W", Room[0] },
                { "E", Room[2] }
            };


            _room[0].AddConnection(exits);

            _room[1].AddConnection(exits2);


            Console.WriteLine(
                $"{_room[0].Description} { string.Join(", " , _room[0].Connections.Keys)}");


         
           //Console.WriteLine(_room[1].Description, _room[1].Connections.Keys);

            /*
            foreach (Room room in _room)
            {
                Console.WriteLine(room.Description, room.Item, room.Enemy);
            }~

            */
  
            //CreatePlayer();
        }


        private void TestRooms(string description, Item item, Enemy enemy)
        {

            _room[a] = new Room(description, item, enemy);
            a++;
        }


        private void ReadMap()
        {
            {
                using StreamReader sr = new StreamReader("Dungeon/Rooms/Map.txt");

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

        
        private void CreatePlayer()
        {
            Player player = new Player("Player");
        }



        // Action methods from controller


        public int UpdatePlayerPos()
        {
            return playerPos;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool canMove(string input)
        {   
            return _room[playerPos].Connections.ContainsKey(input);
        }

    

    }
}