namespace Dungeon
{
    /// <summary>
    /// Represents the game entry point.
    /// 3 Instaces a created: Model, View and Controller
    /// Finaly the controller is run (Game loop)
    /// </summary>
    class Program
    {
        // DEBUG ROOM
        private static Room[,] room = new Room[15, 5];

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

            
            Room[,] room = new Room[16, 5];

            DebugRoom();


            // Instantiate a game   (controller) 
            Game game = new Game();

            // Instantiate a view 
            // pass as param (game, room) 
            IView view = new View(game, room);
            
            // Run the game         
            game.Start(view);
        }


        private static void DebugRoom()
        {

            room[0, 0]  = new Room();
            room[1, 0]  = new Room();
            room[2, 0]  = new Room();
            room[3, 0]  = new Room();
            room[4, 0]  = new Room();
            room[5, 0]  = new Room();
            room[6, 0]  = new Room();
            room[7, 0]  = new Room();
            room[8, 0]  = new Room();
            room[9, 0]  = new Room();
            room[10, 0] = new Room();
            room[11, 0] = new Room();
            room[12, 0] = new Room();
            room[13, 0] = new Room();
            room[14, 0] = new Room();
            room[15, 0] = new Room();
        }
    }
}
