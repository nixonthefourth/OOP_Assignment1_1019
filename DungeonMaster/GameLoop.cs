namespace DungeonMaster
{
    public class GameLoop
    {
        // Variables
        public string WelcomeMessage { get; set; }
        public bool GameEnded { get; set; }
        
        // Game Loop
        public void Game()
        {
            // Set Variables
            GameEnded = false;
            WelcomeMessage = "Welcome to the Dungeon Master! \n \n";
            
            // Gameloop
            // Output the Entrance
            Visuals.DisplayMessage(WelcomeMessage.ToUpper());
            
            // Set the username
            Player thePlayer = new Player();
            thePlayer.SetUserName();
            thePlayer.SetHealth();
            thePlayer.SetInventory();
        }
    }
}