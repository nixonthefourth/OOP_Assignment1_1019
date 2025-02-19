namespace DungeonMaster
{
    public class Player
    {
        // Varaibles
        public string PlayerName { get; private set; }
        
        // Methods
        
        // Getters
        
        // Name
        // Get Name
        public string GetCharacterName()
        {
            // Gets user's name
            Helper.DisplayMessage("Enter your name, mighty warrior: ");
            PlayerName = Console.ReadLine();
            
            // Return
            return PlayerName;
        }
    }
}