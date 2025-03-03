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
        
        // Items
        // Stores An Item In The Individual Room
        public Items RoomItem { get; set; }
        
        /*
         * METHODS
         * METHODS
         * METHODS
         */
        
        // TODO – Create Method For Room Navigation
        // TODO – Create Probability Of An Exit Placement (Ignore Complexity Level)
        
        /*
         * GENERATORS
         * GENERATORS
         * GENERATORS
         */
        
        // Generates A Random Enemy In The Room
        public void GenerateRoomEnemy()
        {
            // Spawn An Enemy
            // 50% Chance Of The Event. 0 To 100 Would Be A Mess From A Mathematical Perspective. Email Me For Proof.
            if (_randomInteger.Next(0, 2) == 1)
            {
                // Selects The Enemy
                RoomEnemy = Enemies.SelectEnemy();
            }

            // The Case, Where Enemy Doesn't Spawn At All
            else
            {
                RoomEnemy = null;
            }
        }
        
        // Generates A Random Intem In The Room
        public void GenerateRoomItem()
        {
            // Generate An Item
            
            // 50% Chance Of The Event Happening.
            // 0 To 100 Would Be A Mess From A Mathematical Perspective. Email Me For Proof.
            if (_randomInteger.Next(0, 2) == 1)
            {
                // Selects The Enemy
                RoomItem = Items.SelectItem();
            }

            // The Case, Where Item Doesn't Spawn At All
            else
            {
                RoomItem = null;
            }
        }
    }
}