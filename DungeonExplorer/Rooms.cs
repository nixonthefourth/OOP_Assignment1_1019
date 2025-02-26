namespace DungeonExplorer
{
    public class Rooms
    {
        // Variables
        public bool ExitFound { get; set; }
        
        // Methods
        
        // TODO – Create Method For Room Navigation
        // TODO – Create Method For Room Description
        // TODO – Create Probability Of An Exit Placement (Ignore Complexity Level)
        // TODO – Create Item Generation (Using Probabilities)
        // TODO – Link Enemies.cs
        // TODO – Create Method For Enemy Placement
        // Setters
        
        // Set Exit Flag
        public bool AdventureExitFound()
        {
            ExitFound = false;
            return ExitFound;
        }
    }
}