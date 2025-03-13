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
        public string EnemyName { get; set; }
        public int EnemyHealth { get; set; }
        public int EnemyDamage { get; set; }
        private static Random _randomInteger = new Random();
        
        /// <summary>
        /// Damage player
        /// </summary>
        /// <param name="enemyDamage">Damage that enemy deals.</param>
        /// <param name="playerHealth">Health that player currently has.</param>
        /// <param name="enemyHealth">Health the enemy has now.</param>
        /// <returns>
        /// Player's health.
        /// </returns>
        /// <remarks>
        /// Assigns The Probability Of Damaging Someone
        /// If It's Less Than 10 And More Than 7, Then Player Receieves The Damage
        /// </remarks>
        public int DamagePlayer(int enemyDamage, int playerHealth, int enemyHealth)
        {
            enemyHealth = EnemyHealth;
            
            Random rnd = new Random();
            int randomValue = rnd.Next(0, 10);
            
            if (randomValue >= 7)
            {
                playerHealth -= enemyDamage;
                Helper.DisplayMessage("That's what you get... Injured! \n \n".ToUpper());
            } else {
                Helper.DisplayMessage("Enemy's Hit's Missed! \n \n".ToUpper());
            }
            
            if (playerHealth < 0)
            {
                playerHealth = 0;
            }
            
            Helper.DisplayMessage($"Player's Health: {playerHealth} \n \n".ToUpper());
            Helper.DisplayMessage($"Enemy's Health: {enemyHealth} \n \n".ToUpper());
            
            return playerHealth;
        }
        
        /// <summary>
        /// Constructs the enemy
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="damage"></param>
        public Enemies(string name, int health, int damage)
        {
            EnemyName = name;
            EnemyHealth = health;
            EnemyDamage = damage;
        }
        
        /// <summary>
        /// Select An Enemy Randomly
        /// Calling Static, Since We Need The Universal Type, Rather Than An Instance
        /// Creates a list
        /// </summary>
        /// <returns>
        /// Return Values
        /// Using Count, Since It Returns The Exact Number Of Elements In The List
        /// </returns>
        public static Enemies SelectEnemy()
        {
            List<Enemies> enemyGameList = new List<Enemies>
            {
                new Enemies("Kevin Jacques",100,65),
                new Enemies("Greyhound",100,20),
                new Enemies("Patrick Bateman",100,30),
                new Enemies("Biggleswade Skeleton",100,15),
            };
            
            return enemyGameList[_randomInteger.Next(enemyGameList.Count)];
        }
    }
}