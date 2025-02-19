namespace DungeonMaster
{
    public class Player
    {
        public int PlayerHealth { get; set; }
        public string PlayerItems { get; set; }
        public string UserName { get; set; }
        public string UserNameMessage { get; private set; }
        public string PlayerWeapons { get; set; }

        // Set Username
        public void SetUserName()
        {
            // Output the Message
            UserNameMessage = "Mighty warrior, what is your name? ";
            Visuals.DisplayMessage(UserNameMessage.ToUpper());
            
            // Get the Text
            UserName = Console.ReadLine();
            
            // Return the Input
            string userReturnMessage = $"Welcome mighty {UserName}!";
            Visuals.DisplayMessage(userReturnMessage.ToUpper());
        }
        
        // Set Health
        public void SetHealth()
        {
            PlayerHealth = 100;
        }
        
        // Set Items in the Inventory
        public void SetInventory()
        {
            PlayerItems = "Empty Inventory";
        }
        
        // Set Player's Damage
        public void SetWeapons()
        {
            PlayerWeapons = "Empty Weapons";
        }
        
        // Damage Someone
        public int DamageEnemy(int enemyHealth, int playerDamage, string playerWeapon)
        {
            return 0;
        }
    }
}