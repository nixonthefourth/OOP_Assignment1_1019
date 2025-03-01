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
            // Sets Initial Health Of The Individual Enemy
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
            int randomValue = rnd.Next(0, 10);
            
            // Assigns The Probability Of Damaging Someone
            // If It's Less Than 10 And More Than 7, Then Player Receieves The Damage
            if (randomValue >= 7)
            {
                // Takes Away User's Health
                playerHealth -= enemyDamage;
                
                // Message
                Helper.DisplayMessage("That's what you get... Injured! \n \n".ToUpper());
            }

            else
            {
                Helper.DisplayMessage("Enemy's Hit's Missed! \n \n".ToUpper());
            }
            
            // Enter Message
            Helper.DisplayMessage($"Player's Health: {playerHealth} \n".ToUpper());
            Helper.DisplayMessage($"Enemy's Health: {enemyHealth} \n \n".ToUpper());
            
            // Returns
            return playerHealth;
        }
    }
}