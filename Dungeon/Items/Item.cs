namespace Dungeon.Items
{
    /// <summary>
    /// Abstract representation of an object (in-game item) 
    /// </summary>
    public abstract class Item
    {

        public string Name { get; }



        
        public Item(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Allows the player to interact with the items.
        /// Method is overriden in by all items subclasses.
        /// </summary>

        public abstract void Interact();

        public abstract int Use();
        
           
        
    }
}