using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    
    public class Rooms
    {
        private Random _randomInteger = new Random();
        public string WeaponName { get; set; }
        public string PotionName { get; set; }
        public Enemies RoomEnemy { get; set; }
        public Items RoomItem { get; set; }
        public bool RoomExit { get; private set; }
        
        /// <summary>
        /// Generates the random enemy in the room from a predefined list of enemies in Enemies.cs.
        /// </summary>
        /// <remarks>
        /// Spawns An Enemy
        /// 50% Chance Of The Event. 0 To 100 Would Be A Mess From A Mathematical Perspective. Email Me For Proof.
        /// </remarks>
        public void GenerateRoomEnemy()
        {
            if (_randomInteger.Next(0, 2) == 1)
            {
                RoomEnemy = Enemies.SelectEnemy();
            } else {
                RoomEnemy = null;
            }
        }
        /// <summary>
        /// Generates the item in the room randomly.
        /// </summary>
        /// <remarks>
        /// 50% Chance Of The Event Happening.
        /// 0 To 100 Would Be A Mess From A Mathematical Perspective. Email Me For Proof.
        /// If there is an item, the alue is assigned, otherwise value is set to null.
        /// </remarks>
        public void GenerateRoomItem()
        {
            if (_randomInteger.Next(0, 2) == 1)
            {
                RoomItem = Items.SelectItem();
            } else {
                RoomItem = null;
            }
        }
        /// <summary>
        /// Generates A Random Exit In The Room.
        /// 1 In 3 Chance Of Exit Appearing In The Room
        /// </summary>
        public void GenerateRoomExit()
        {
            if (_randomInteger.Next(0, 3) == 1)
            {
                RoomExit = true;
            } else {
                RoomExit = false;
            }
        }
    }
}