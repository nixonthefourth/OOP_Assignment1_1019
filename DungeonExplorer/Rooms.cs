namespace DungeonExplorer
{
    public class Rooms
    {
        /*
         * VARIABLES
         * VARIABLES
         * VARIABLES
         */
        
        // System
        public bool ExitFound { get; set; }
        
        // Randomisation Seed
        private Random _randomInteger = new Random();
        
        // Weapons
        public string WeaponName { get; set; }
        
        // Potions
        public string PotionName { get; set; }
        
        // Enemies
        // Stores An Enemy In The Individual Room
        public Enemies RoomEnemy { get; set; }
        
        /*
         * METHODS
         * METHODS
         * METHODS
         */
        
        // TODO – Create Method For Room Navigation
        // TODO – Create Probability Of An Exit Placement (Ignore Complexity Level)
        // TODO – Create Item Generation (Using Probabilities, Similar To The Enemy Stuff)
        
        /*
         * SETTERS
         * SETTERS
         * SETTERS
         */
        
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
        
        /*
         * GENERATORS
         * GENERATORS
         * GENERATORS
         */
        
        // Generates Room With A Random Enemy
        public void GenerateRoomEnemy()
        {
            // Spawn An Enemy
            // 50% Chance Of The Event. 0 To 100 Would Be A Mess From A Mathematical Perspective. Email Me For Proof.
            if (_randomInteger.Next(0, 2) == 1)
            {
                // Selects The Enemy
                RoomEnemy = Enemies.SelectEnemy();
                // Helper.DisplayMessage($"{RoomEnemy} is lurking behind you...".ToUpper());
            }

            // The Case, Where Enemy Doesn't Spawn At All
            else
            {
                RoomEnemy = null;
                // Helper.DisplayMessage("The room is suspiciously empty...".ToUpper());
            }
        }
    }
}