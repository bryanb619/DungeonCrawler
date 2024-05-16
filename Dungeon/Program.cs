namespace Dungeon
{
    /// <summary>
    /// Represents the game entry point.
    /// 3 Instaces a created: Model, View and Controller
    /// Finaly the controller is run (Game loop)
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point of the game.
        /// 3 instances are created: Model, Controller and View.
        /// Model       = Room class => represents Program logic. 
        /// Controller  = Game class => represents the game loop.
        /// View        = View class => represents the user interface (UI).
        /// </summary>
        /// <param name="args">Not used</param>
        private static void Main(string[] args)
        {
            // Instantiate a room   (model)
            Room room = new Room();

            // Instantiate a game   (controller) 
            Game game = new Game();

            // Instantiate a view 
            // pass as param (game, room) 
            View view = new View(game, room);
            
            // Run the game         
            game.Start(view);
        }
    }
}
