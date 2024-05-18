using System;
using System.Collections.Generic;
using System.IO;
using Dungeon.Items;
using Dungeon.Characters;


namespace Dungeon
{

    /// <summary>
    /// 
    /// </summary>
    public class Room
    {

        // Room properties
        public string Description { get; }

        public Dictionary<string, Room> Connections { get;  }

        public Item Item { get; }

        public Enemy Enemy { get; }

        public Room(string description, Dictionary<string, Room> exits, Item item, Enemy enemy)
        {

            // string name, string description, List<Char> exits, Item item, Enemy enemy
            Description = description;
            Connections = exits;
            Item = item;
            Enemy = enemy;
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadRoom()
        {
            {
                try
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
                        if(line.Contains("\t"))
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

                catch (Exception)
                {
                    

                }
               
            }
        }
    }
}