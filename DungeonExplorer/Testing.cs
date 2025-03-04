using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    
    public class Testing
    {
        /*
         * VARIABLES
         * VARIABLES
         * VARIABLES
         */
        
        // Creates Test Entity Of A Player
        private Player _testPlayer = new Player();
        
        // Creates Test Entity Of A Room
        private Rooms _testRoom = new Rooms();
        
        /*
         * METHODS
         * METHODS
         * METHODS
         */
        
        // Run Unified Tests For Player
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
        
        // Test Room Generation Sequence
        public void RunRoomTests()
        {
            // Generators
            _testRoom.GenerateRoomEnemy();
            _testRoom.GenerateRoomItem();
            _testRoom.GenerateRoomExit();
            
            // Actual Testing Sequence
            Debug.Assert(_testRoom.RoomExit == true || _testRoom.RoomExit == false, "Room exit generation has failed!");
            Debug.Assert(_testRoom.RoomEnemy == null || _testRoom.RoomEnemy != null, "Enemy generation has failed!");
            Debug.Assert(_testRoom.RoomItem == null || _testRoom.RoomItem != null, "Item generation has failed");
        }
    }
}