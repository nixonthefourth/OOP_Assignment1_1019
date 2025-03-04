using System.Diagnostics;

namespace DungeonExplorer
{
    public class Testing
    {
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
            
            // Creates Test Entity Of A Player
            Player testPlayer = new Player();
            
            // Tests Player's Parameters
            testPlayer.PlayerHealth = 100;
            testPlayer.PlayerDamage = 40;
            testPlayer.PlayerInventoryItem = "Axe";
            
            // Testing Sequence
            Debug.Assert(testPlayer.PlayerHealth == 100, "Starting health should be 100.");
            Debug.Assert(testPlayer.PlayerDamage == 20, "Damage of sword should be 20.");
        }
    }
}