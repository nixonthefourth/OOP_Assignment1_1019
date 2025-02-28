namespace DungeonExplorer
{
    public class Player
    {
        // Varaibles
        public string PlayerName { get; private set; }
        public int PlayerHealth { get; private set; }
        public int PlayerDamage { get; private set; }
        public string PlayerInventoryItem { get; private set; }
        
        // Methods
        
        // TODO – Link Files
        
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
        
        // Damage
        
        // Set Player's Damage
        public int SetPlayerDamage()
        {
            // Return
            return PlayerDamage = 0;
        }
        
        // Actions
        
        // Damage Enemy
        public int DamageEnemy(int enemyHealth, int playerDamage)
        {
            enemyHealth -= playerDamage;

            // Checks Whether Enemy Is Alive
            if (enemyHealth <= 0)
            {
                Helper.DisplayMessage("Enemy is dead!".ToUpper());
            }
            
            // Returns Enemy's Health
            return enemyHealth;
        }
        
        // Pick Up An Inventory Item
        public void PickPlayerItem(string itemName)
        {
            // Changes Parameters & Stats Of The Player
            // Void, Since Data Is Assigned, Rather Than Retrieved

            // Assigning Items
            // Weapons
            // If Sword Is Found
            if (itemName == "Sword")
            {
                PlayerDamage = 20;
                PlayerInventoryItem = itemName;
            }
            
            // If Axe Is Found
            else if (itemName == "Axe")
            {
                PlayerDamage = 40;
                PlayerInventoryItem = itemName;
            }
            
            // Setting Potions
            // Healing
            else if (itemName == "Cheeky Potion")
            {
                // Full Regeneration For Simplicity's Sake
                PlayerHealth = 100;
            }
            
            // The Damaging One
            else if (itemName == "Potion of Biggleswade")
            {
                // This Is What Happens If You Go To Biggleswade
                PlayerHealth -= 20;
            }
        }
    }
}