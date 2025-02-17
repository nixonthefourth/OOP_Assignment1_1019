namespace DungeonMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variables
            string welcomeMessage = "Welcome to Dungeon Master! \n";
            
            GameFunctions game = new GameFunctions();
            game.DisplayMessage(welcomeMessage.ToUpper());
        }
    }
}