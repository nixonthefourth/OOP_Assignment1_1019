namespace DungeonExplorer
{
    
    public class Items
    {
        public string ItemName { get; set; }
        public int ItemDamage { get; set; }
        public int ItemHeal { get; set; }
        private static Random _randomInteger = new Random();
  
        /// <summary>
        /// Creates the item in the game.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="heal"></param>
        /// <param name="damage"></param>
        public Items(string name, int heal, int damage)
        {
            ItemName = name;
            ItemHeal = heal;
            ItemDamage = damage;
        }
        
        /// <summary>
        /// Select An Item Randomly
        /// Calling Static, Since We Need The Universal Type, Rather Than An Instance
        /// </summary>
        /// <returns>
        /// Return Values
        /// Using Count, Since It Returns The Exact Number Of Elements In The List
        /// </returns>
        public static Items SelectItem()
        {
            List<Items> itemGameList = new List<Items>
            {
                new Items("Sword",0,20),
                new Items("Axe",0,40),
                new Items("Cheeky Potion",20,0),
            };
            
            return itemGameList[_randomInteger.Next(itemGameList.Count)];
        }
    }
}