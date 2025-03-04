using System.Diagnostics;

namespace DungeonExplorer
{
    public class Testing
    {
        /*
         * VARIABLES
         * VARIABLES
         * VARIABLES
         */
        
        // Creates Test Entity Of A Player
        private Player _testPlayer = new Player();
        
        /*
         * METHODS
         * METHODS
         * METHODS
         */
        
        // Run Unified Tests For Player
        public void RunPlayerTests()
        {
            // Display Message
            Debug.WriteLine("–––Starting Test Sequence–––");
            
            // Tests Player's Parameters
            _testPlayer.PlayerHealth = 100;
            _testPlayer.PlayerDamage = 40;
            _testPlayer.PlayerInventoryItem = "Axe";
            
            // Testing Sequence
            Debug.Assert(_testPlayer.PlayerHealth == 100, "Starting health should be 100.");
            Debug.Assert(_testPlayer.PlayerDamage == 20, "Damage of sword should be 20.");
        }
        
        // Run Combat System Tests (We Damage Enemy In This Case)
        public void RunyDamageTests()
        {
            // Initialise Some Enemy With Some Health
            int enemyHealth = 100;
            
            // Actual Testing
            enemyHealth = _testPlayer.DamageEnemy(enemyHealth, _testPlayer.PlayerDamage);
            Debug.Assert(enemyHealth <= 100, "Enemie's health can't go higher than 100.");
        }
    }
}