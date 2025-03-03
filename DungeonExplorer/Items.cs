namespace DungeonExplorer
{
    public class Items
    {
        /*
         * VARIABLES
         * VARIABLES
         * VARIABLES
         */
        
        // Items
        
        public string ItemName { get; set; }
        public int ItemDamage { get; set; }
        public int ItemHeal { get; set; }
        
        // System
        
        private static Random _randomInteger = new Random();
        
        /*
         * METHODS
         * METHODS
         * METHODS
         */
        
        /*
         * CONSTRUCTORS
         * CONSTRUCTORS
         * CONSTRUCTORS
         */
        
        // Create Inventory Item
        public Items(string name, int heal, int damage)
        {
            // Assign individual Values
            ItemName = name;
            ItemHeal = heal;
            ItemDamage = damage;
        }
        
        /*
         * ACTIONS
         * ACTIONS
         * ACTIONS
         */
        
        // Select An Item Randomly
        // Calling Static, Since We Need The Universal Type, Rather Than An Instance
        public static Items SelectItem()
        {
            // Create A List Of All Items
            List<Items> itemGameList = new List<Items>
            {
                new Items("Sword",0,20),
                new Items("Axe",0,40),
                new Items("Cheeky Potion",20,0),
                new Items("Biggleswade Potion",0,20),
            };
            
            // Return Values
            // Using Count, Since It Returns The Exact Number Of Elements In The List
            return itemGameList[_randomInteger.Next(itemGameList.Count)];
        }
    }
}