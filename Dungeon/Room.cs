using Dungeon.Items;
using Dungeon.Characters;
using System.Collections.Generic;


namespace Dungeon
{

    /// <summary>
    /// Method that has the information of each room such as the 
    /// description, the rooms that are connected with the current room, the 
    /// item if there's any, the enemy if there's any and the unique id number.
    /// </summary>
    public class Room
    {

        // Room properties
        public string Description { get; }

        public Dictionary<string, Room> Connections { get; private set;}

        public Item Item { get; set; }

        public Enemy Enemy { get; private set; }

        public int Id { get; }


        /// <summary>
        /// Method that has the information of each room such as the 
        /// description, the item if there's any, the enemy if there's any and
        /// the unique id number.
        /// </summary>
        /// <param name="description">Description of the room the player
        /// entered</param>
        /// <param name="item">Description of item inside the room</param>
        /// <param name="enemy">Enemy that is in the room</param>
        /// <param name="id">Number that identifies the room</param>
        public Room(string description, Item item, Enemy enemy, int id)
        {

            // string name, string description, Item item, Enemy enemy
            Description     = description;
            Item            = item;
            Enemy           = enemy;
            Id              = id;
        }
        

        /// <summary>
        /// Method adds connections to a instance of room.
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