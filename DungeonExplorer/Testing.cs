using System.Diagnostics;


namespace DungeonExplorer
{
    
    public class Testing
    {
        private Player _testPlayer = new Player();
        private Rooms _testRoom = new Rooms();
        
        /// <summary>
        /// Runs tests on the user so we check whether the user was crated correctly, and we check the parameters.
        /// </summary>
        public void RunPlayerTests()
        {
            // Tests Player's Parameters
            _testPlayer.PlayerHealth = 100;
            _testPlayer.PlayerDamage = 40;
            _testPlayer.PlayerInventoryItem = "Axe";
            
            // Testing Sequence
            Debug.Assert(_testPlayer.PlayerHealth <= 100, "Health can't be more than 100.");
            Debug.Assert(_testPlayer.PlayerDamage != 0, "Player's damage can't be zero.");
        }
        
        /// <summary>
        /// Runs the test sequence for the rooms, whether the room has been generated properly.
        /// </summary>
        public void RunRoomTests()
        {
            _testRoom.GenerateRoomEnemy();
            _testRoom.GenerateRoomItem();
            _testRoom.GenerateRoomExit();
            
            Debug.Assert(_testRoom.RoomExit == true || _testRoom.RoomExit == false, "Room exit generation has failed!");
            Debug.Assert(_testRoom.RoomEnemy == null || _testRoom.RoomEnemy != null, "Enemy generation has failed!");
            Debug.Assert(_testRoom.RoomItem == null || _testRoom.RoomItem != null, "Item generation has failed");
        }
    }
}