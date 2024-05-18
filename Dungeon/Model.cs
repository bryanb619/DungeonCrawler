using System;
using System.Collections.Generic;
using Dungeon.Items;
using Dungeon.Characters;

namespace Dungeon
{
    public class Model
    {

        private Room[] room = new Room[15];

        public Room[] Room { get; private set; }

      

        public void CreateRooms(string description, Dictionary<string, Room> exits, Item item, Enemy enemy)
        {
            for (int i = 0; i < 15; i++)
            {

                room[i] = new Room(description, exits, item, enemy);
                
                Room[i] = room[i];

                Console.WriteLine($" Description: {room[0].Description}");
                Console.WriteLine($" Conections: {room[0].Connections.Values.ToString()}");
                Console.WriteLine($" Item: {room[0].Item.Name}");
                Console.WriteLine($" Enemy: {room[0].Enemy.Name}");
            }
        }
    
    }
}