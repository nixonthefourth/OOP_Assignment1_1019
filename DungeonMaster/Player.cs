namespace DungeonMaster
{
    public class Player
    {
        // Varaibles
        public string PlayerName { get; private set; }
        public int PlayerHealth { get; private set; }
        
        // Methods
        
        // Getters
        
        // Name
        // Get Name
        public string GetCharacterName()
        {
            // Gets user's name
            Helper.DisplayMessage("Enter your name, mighty warrior: ".ToUpper());
            PlayerName = Console.ReadLine();
            
            // Return
            return PlayerName;
        }
        
        // Setters
        
        // Health
        
        // Set Player's Health
        public int SetPlayerHealth(int playerHealth)
        {
            PlayerHealth = playerHealth;
            return PlayerHealth;
        }
    }
}