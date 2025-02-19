namespace DungeonMaster
{
    public class GameLoop
    {
        // Variables
        public string WelcomeMessage { get; set; }
        
        // Game Loop
        public void Game()
        {
            // Set Variables
            WelcomeMessage = "Welcome to the Dungeon Master! \n \n";
            
            // Gameloop
            // Output the Entrance
            Visuals.DisplayMessage(WelcomeMessage.ToUpper());
        }
    }
}