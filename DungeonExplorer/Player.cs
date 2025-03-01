using System.Diagnostics;

namespace DungeonExplorer
{
    public class Player
    {
        /*
         * VARIABLES
         * VARIABLES
         * VARIABLES
         */
        
        public string PlayerName { get; private set; }
        public int PlayerHealth { get; private set; }
        public int PlayerDamage { get; private set; }
        public string PlayerInventoryItem { get; private set; }
        
        /*
         * METHODS
         * METHODS
         * METHODS
         */
        
        /*
         * GETTERS
         * GETTERS
         * GETTERS
         */
        
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
        
        /*
         * SETTERS
         * SETTERS
         * SETTERS
         */
        
        // Health
        
        // Set Player's Health
        public int SetPlayerHealth(int playerHealth)
        {
            PlayerHealth = playerHealth;
            return PlayerHealth;
        }
        
        // Damage
        
        // Set Player's Initial Damage
        public int SetPlayerDamage()
        {
            // Return
            return PlayerDamage = 5;
        }
        
        // Actions
        
        // Damage Enemy
        
        public int DamageEnemy(int enemyHealth, int playerDamage)
        {
            // Generates Random Seed
            Random rnd = new Random();
            int randomValue = rnd.Next(0, 10);
            
            // Assigns The Probability Of Damaging Someone
            // If It's Less Than 100 And More Than 3, Then Enemy Receieves The Damage
            if (randomValue >= 3)
            {
                // Takes Away User's Health
                enemyHealth -= playerDamage;
                
                // Message
                Helper.DisplayMessage("Enemy Is Injured!! \n \n".ToUpper());
            }

            else
            {
                Helper.DisplayMessage($"{PlayerName}'s Hit Was Missed! \n \n".ToUpper());
            }

            // Checks Whether Enemy Is Alive
            if (enemyHealth <= 0)
            {
                Helper.DisplayMessage("Enemy is dead! \n \n".ToUpper());
            }
            
            // Returns Enemy's Health
            return enemyHealth;
        }
        
        // Pick Up An Inventory Item
        public void PickPlayerItem(string itemName)
        {
            // Debug
            Debug.Assert(itemName != null && itemName != "", "Item name should not be empty!");
            
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