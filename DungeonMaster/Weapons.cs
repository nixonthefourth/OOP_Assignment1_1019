namespace DungeonMaster
{
    public class Weapons
    {
        // Variables
        // Weapons
        public string WeaponName { get; set; }
        public int WeaponDamage { get; set; }
        
        // Methods
        public void SetRoomWeapon(string weaponName, int weaponDamage)
        {
            // Checks for the absence of the parameters
            if (weaponName == null || weaponName == "" || weaponName == " ")
            {
                Console.WriteLine("System Error | Weapon Undefined");
                System.Environment.Exit(1);
            }

            else if (weaponDamage == null || weaponDamage == 0)
            {
                Console.WriteLine("System Error | Damage Undefined");
                System.Environment.Exit(1);
            }

            // Otherwise, we set the values assigned
            else
            {
                weaponDamage = WeaponDamage;
                weaponName = WeaponName;
            }
        }
    }
}