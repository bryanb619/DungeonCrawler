using Dungeon.Items;
using Dungeon.Characters;
using System.Collections.Generic;


namespace Dungeon
{

    /// <summary>
    /// 
    /// </summary>
    public class Room
    {

        // Room properties
        public string Description { get; }

        public Dictionary<string, Room> Connections { get; private set;}

        public Item Item { get; set; }

        public Enemy Enemy { get; }
        

        public Room(string description, Item item, Enemy enemy)
        {

            // string name, string description, List<Char> exits, Item item, Enemy enemy
            Description     = description;
            Item            = item;
            Enemy           = enemy;
        }
        

        /// <summary>
        /// Method adds connections to a instance of room.
        ///  
        /// </summary>
        /// <param name="exits">
        /// Must receive dictionary with string as key and Room as value of this
        /// dictionary as parameter.
        /// Keys are equal to  W, E, N, S (Representing West, East, North, South)
        /// Values are equal to the room instance that the key is pointing to.
        /// </param>
        public void AddConnection(Dictionary<string, Room> exits)
        {
            // Add a connection to the room
            Connections     = exits;
        }
    }
}