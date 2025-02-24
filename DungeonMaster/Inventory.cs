namespace DungeonMaster
{
    public class Inventory
    {
        // Variables
        
        // Weapons
        public string WeaponName { get; set; }
        
        // Potions
        public string PotionName { get; set; }
        public int PotionDamage { get; set; }
        
        // Methods
        
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
        public void SetRoomPotion(string potionName, int potionDamage)
        {
            // Checks for the absence of the parameters
            // Name Check
            if (potionName == null || potionName == "" || potionName == " ")
            {
                Console.WriteLine("System Error | Weapon Undefined");
                System.Environment.Exit(1);
            }
            
            // Damage Value Check
            else if (potionDamage == null || potionDamage == 0)
            {
                Console.WriteLine("System Error | Damage Undefined");
                System.Environment.Exit(1);
            }

            // Otherwise, we set the values assigned
            else
            {
                potionName = PotionName;
                potionDamage = PotionDamage;
            }
        }
        
        // Getters
        
        // Weapons
        
        // Name
        public string GetWeaponName()
        {
            return WeaponName;
        }
    }
}