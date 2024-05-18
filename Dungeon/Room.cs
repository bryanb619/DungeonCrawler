using System;
using System.Collections.Generic;
using Dungeon.Items;
using Dungeon.Characters;
using System.IO;


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

        public Item Item { get; }

        public Enemy Enemy { get; }
        

        public Room(string description, Item item, Enemy enemy)
        {

            // string name, string description, List<Char> exits, Item item, Enemy enemy
            Description     = description;
            Item            = item;
            Enemy           = enemy;
        }

        public void AddConnection(Dictionary<string, Room> exits)
        {
            // Add a connection to the room
            Connections     = exits;
        }
    }
}