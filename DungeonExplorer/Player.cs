namespace DungeonExplorer
{
    
    public class Player
    {
        public string PlayerName { get; private set; }
        public int PlayerHealth { get; set; }
        public int PlayerDamage { get; set; }
        public string PlayerInventoryItem { get; set; }
        private Random _randomInteger = new Random();
        
        /// <summary>
        /// Get Player's Name and check for the errors.
        /// </summary>
        /// <returns>
        /// Returns the value of the username.
        /// </returns>
        public string GetCharacterName()
        {
            while (true)
            {
                Helper.DisplayMessage("Enter your name, mighty warrior: ".ToUpper());
                PlayerName = Console.ReadLine();

                if (PlayerName.Length == 0 || PlayerName == "" || PlayerName == " ")
                {
                    Helper.DisplayMessage("Invalid name. \n \n".ToUpper());
                } else {
                    break;
                }
            }
            
            return PlayerName;
        }
        /// <summary>
        /// Damage Enemy
        /// </summary>
        /// <param name="enemyHealth">Health of the enemy</param>
        /// <param name="playerDamage">Damage that player deals</param>
        /// <returns>Health of enemy using enemyHealth</returns>
        /// <remarks>
        /// Assigns The Probability Of Damaging Someone
        /// If It's Less Than 10 And More Than 3, Then Enemy Receieves The Damage
        /// </remarks>
        public int DamageEnemy(int enemyHealth, int playerDamage)
        {
            int randomValue = _randomInteger.Next(0, 10);
            if (randomValue >= 3)
            {
                enemyHealth -= playerDamage;
                
                // Message
                Helper.DisplayMessage("Enemy Is Injured!! \n \n".ToUpper());
            } else {
                Helper.DisplayMessage($"{PlayerName}'s Hit Was Missed! \n \n".ToUpper());
            }

            if (enemyHealth <= 0)
            {
                Helper.DisplayMessage("Enemy is dead! \n \n".ToUpper());
            }
            
            return enemyHealth;
        }
    }
}