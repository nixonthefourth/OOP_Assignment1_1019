using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    
    public class Enemies
    {
        /*
         * VARIABLES
         * VARIABLES
         * VARIABLES
         */
        
        // Enemy Stuff
        public string EnemyName { get; set; }
        public int EnemyHealth { get; set; }
        public int EnemyDamage { get; set; }
        
        // System
        
        // Randomisation Seed
        private static Random _randomInteger = new Random();
        
        /*
         * METHODS
         * METHODS
         * METHODS
         */
        
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
            } else {
                Helper.DisplayMessage("Enemy's Hit's Missed! \n \n".ToUpper());
            }
            
            // Enter Message
            Helper.DisplayMessage($"Player's Health: {playerHealth} \n \n".ToUpper());
            Helper.DisplayMessage($"Enemy's Health: {enemyHealth} \n \n".ToUpper());
            
            // Returns
            return playerHealth;
        }
        
        /*
         * CONSTRUCTORS
         * CONSTRUCTORS
         * CONSTRUCTORS
         */
        
        // Create An Enemy
        public Enemies(string name, int health, int damage)
        {
            // Assign individual Values
            EnemyName = name;
            EnemyHealth = health;
            EnemyDamage = damage;
        }
        
        // Select An Enemy Randomly
        // Calling Static, Since We Need The Universal Type, Rather Than An Instance
        public static Enemies SelectEnemy()
        {
            // Create A List Of All Enemies
            List<Enemies> enemyGameList = new List<Enemies>
            {
                new Enemies("Kevin Jacques",100,65),
                new Enemies("Greyhound",100,20),
                new Enemies("Patrick Bateman",100,30),
                new Enemies("Biggleswade Skeleton",100,15),
            };
            
            // Return Values
            // Using Count, Since It Returns The Exact Number Of Elements In The List
            return enemyGameList[_randomInteger.Next(enemyGameList.Count)];
        }
    }
}