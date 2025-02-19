namespace DungeonMaster
{
    public class Rooms
    {
        // Variables
        public bool ExitFound { get; set; }
        
        // Methods
        
        // Setters
        
        // Set Exit Flag
        public bool AdventureExitFound()
        {
            ExitFound = false;
            return ExitFound;
        }
    }
}