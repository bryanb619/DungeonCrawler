using System;
using System.IO;

namespace Dungeon
{

    /// <summary>
    /// 
    /// </summary>
    public class Room
    {




        public Room()
        {

            // string name, string description, List<Char> exits, Item item, Enemy enemy
            //Name = name;
            //Description = description;
            //Exits = exits;
            //Item = item;
            //Enemy = enemy;

            
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