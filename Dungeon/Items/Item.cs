namespace Dungeon.Items
{
    /// <summary>
    /// Abstract representation of an object(in-game item) 
    /// </summary>
    public abstract class Item
    {
        /// <summary>
        /// Allows the player to interact with the items.
        /// Method is overriden in by all items subclasses.
        /// </summary>
        public virtual void Interact(){}
        
    }
}