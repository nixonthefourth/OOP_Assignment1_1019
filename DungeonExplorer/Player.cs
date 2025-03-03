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
        public int PlayerHealth { get; set; }
        public int PlayerDamage { get; set; }
        public string PlayerInventoryItem { get; private set; }
        
        // Generates Random Seed
        private Random _randomInteger = new Random();
        
        /*
         * METHODS
         * METHODS
         * METHODS
         */
        
        // Get Player's Name
        
        public string GetCharacterName()
        {
            while (true)
            {
                // Gets user's name
                Helper.DisplayMessage("Enter your name, mighty warrior: ".ToUpper());
                PlayerName = Console.ReadLine();

                if (PlayerName.Length == 0 || PlayerName == "" || PlayerName == " ")
                {
                    Helper.DisplayMessage("Invalid name. \n \n".ToUpper());
                }

                else
                {
                    break;
                }
            }
            
            // Return
            return PlayerName;
        }
        
        // Damage Enemy
        
        public int DamageEnemy(int enemyHealth, int playerDamage)
        {
            int randomValue = _randomInteger.Next(0, 10);
            
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
        
        // Pick Up An Inventory Item From The Room
        
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