namespace DungeonExplorer
{
    public class Rooms
    {
        // Variables
        public bool ExitFound { get; set; }
        
        // Weapons
        public string WeaponName { get; set; }
        
        // Potions
        public string PotionName { get; set; }
        public int PotionDamage { get; set; }
        
        // Methods
        
        // TODO – Create Method For Room Navigation
        // TODO – Create Method For Room Description
        // TODO – Create Probability Of An Exit Placement (Ignore Complexity Level)
        // TODO – Create Item Generation (Using Probabilities)
        // TODO – Link Enemies.cs
        // TODO – Create Method For Enemy Placement
        
        // Setters
        
        // Weapons
        public void SetRoomWeapon(string weaponName)
        {
            // Checks for the absence of the parameters
            // Name Check
            if (weaponName == null || weaponName == "" || weaponName == " ")
            {
                Console.WriteLine("System Error | Weapon Undefined");
                System.Environment.Exit(1);
            }

            // Otherwise, we set the values assigned
            else
            {
                WeaponName = weaponName;
            }
        }
        
        // Potions
        public void SetRoomPotion(string potionName)
        {
            // Checks for the absence of the parameters
            // Name Check
            if (potionName == null || potionName == "" || potionName == " ")
            {
                Console.WriteLine("System Error | Weapon Undefined");
                System.Environment.Exit(1);
            }

            // Otherwise, we set the values assigned
            else
            {
                potionName = PotionName;
            }
        }
        
        // Getters
        
        // Weapons
        
        // Name
        public string GetWeaponName()
        {
            return WeaponName;
        }
        
        // Set Exit Flag
        public bool AdventureExitFound()
        {
            ExitFound = false;
            return ExitFound;
        }
    }
}