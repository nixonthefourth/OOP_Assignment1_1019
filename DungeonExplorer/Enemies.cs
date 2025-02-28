namespace DungeonExplorer
{
    public class Enemies
    {
        // Variables
        public string EnemyName { get; set; }
        public int EnemyHealth { get; set; }
        public int EnemyDamage { get; set; }
        
        // Methods
        
        // Getters
        
        // Setters
        
        // Health

        public int SetEnemyHealth()
        {
            // Sets Health Of The Individual Enemy
            EnemyHealth = 100;

            return EnemyHealth;
        }
        
        // Actions
        
        // Damage Player
        public int DamagePlayer(int enemyDamage, int playerHealth, int enemyHealth)
        {
            // Sets Individual Enemy's Health
            enemyHealth = EnemyHealth;
            
            // Generates Random Seed
            Random rnd = new Random();
            int randomValue = rnd.Next(0, 100);
            
            // Assigns The Probability Of Damaging Someone
            // If It's Less Than 100 And More Than 40, Then Player Receieves The Damage
            if (randomValue >= 40 && randomValue <= 100)
            {
                // Takes Away User's Health
                playerHealth -= enemyDamage;
                
                // Message
                Helper.DisplayMessage("Injured!! \n \n");
            }

            else
            {
                Helper.DisplayMessage($"Hit Was Missed!");
            }
            
            // Enter Message
            Helper.DisplayMessage($"Player's Health: {playerHealth}");
            Helper.DisplayMessage($"Enemy's Health: {enemyHealth}");
            
            // Returns
            return playerHealth;
        }
    }
}