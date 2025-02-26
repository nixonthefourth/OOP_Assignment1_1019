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
        public int DamagePlayer(int enemyDamage, int playerHealth)
        {
            // Takes Away User's Health
            playerHealth -= enemyDamage;
            
            // Enter Message
            Helper.DisplayMessage("Damage Sustained! \n");
            Helper.DisplayMessage($"Health: {playerHealth}");
            
            // Returns
            return playerHealth;
        }
    }
}