namespace DungeonExplorer
{
    public class Player
    {
        // Varaibles
        public string PlayerName { get; private set; }
        public int PlayerHealth { get; private set; }
        public int PlayerDamage { get; private set; }
        
        // Methods
        
        // TODO – Create Method To Assign Found Item To Inventory
        // TODO – Link Inventory.cs
        
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
        public int SetPlayerDamage(string weaponName)
        {
            // Selects The In-Game Weapon
            if (weaponName == "Sword")
            {
                PlayerDamage = 20;
            }
            
            else if (weaponName == "Axe")
            {
                PlayerDamage = 40;
            }

            else
            {
                PlayerDamage = 00;
            }
            
            // Return
            return PlayerDamage;
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
    }
}