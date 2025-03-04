using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    
    public class GameLoop
    {
        /*
        There Is 1 Global Player, Hence _player Is Set
        
        There Is 1 Related Global Story That Is
        Referenced Across All The Files, Hence There Is 1 Public instance _story
        */
        
        private Player _player = new Player();
        private Story _story = new Story();
        
        /*
         * GAME LOOP
         * GAME LOOP
         * GAME LOOP
         */
        
        public void Game()
        {
            // Initialises Adventure
            AdventureInit();
            
            // Create Rooms
            
            // Room 1
            Rooms room1 = new Rooms();
            RoomExec(room1);
            
            // Room 2
            Rooms room2 = new Rooms();
            RoomExec(room2);
            
            // Room 3
            Rooms room3 = new Rooms();
            RoomExec(room3);
            
            // Room 4
            Rooms room4 = new Rooms();
            RoomExec(room4);
            
            // Room 5
            Rooms room5 = new Rooms();
            RoomExec(room5);

            // Winning Sequence For Room 5
            if (room5.RoomExit)
            {
                _story.WinAdventure();
            }
        }

        /*
         * STORY SEQUENCE
         * STORY SEQUENCE
         * STORY SEQUENCE
         */
        
        // Initialise Adventure
        private void AdventureInit()
        {
            // Intro To The Adventure
            _story.Welcome();
            _story.StartStory();

            // Confirm Character's Name
            string characterName = _player.GetCharacterName();
            _story.CharacterNameConfirmation(characterName);
            
            // Set Player's Starting Health
            _player.PlayerHealth = 100;
        }

        // Loads The Adventure Into Code, So It's Selected Later
        
        private void AdventureLoad(Rooms curentRoom)
        {
            // Select Event In The Game
            _story.SetAdventureActions();
            
            // Display Messages
            Helper.DisplayMessage($"Now you are neck deep into {_story.AdventureActionName} \n \n".ToUpper());
            
            // Confirmation Action
            _story.ConfirmationMessage();
            // Checks The Action That May Happen In The Selected Adventure Action
            
            // Fight
            if (_story.AdventureActionName == _story.AdventureActions[0])
            {
                // Action Itself
                EnterFight(curentRoom);
                
                // Confirmation Action
                _story.ConfirmationMessage();
            } else if (_story.AdventureActionName == _story.AdventureActions[1]) {
                // Item Search
                ItemFound(curentRoom);
                
                // Action Confrimation
                _story.ConfirmationMessage();
            } else if (_story.AdventureActionName == _story.AdventureActions[2]) {
                // Exit Search
                ExitRoom(curentRoom);
                
                // Confirmation Action
                _story.ConfirmationMessage();
            } else if (_story.AdventureActionName == _story.AdventureActions[3]) {
                // Call Messages
                _story.DwellingMessages();
                
                // Confirmation Action
                _story.ConfirmationMessage();
            }
        }
        
        /*
         * FIGHT
         * FIGHT
         * FIGHT
         */
        
        // Fighting Sequence
        
        private void FightEncounter(Rooms currentRoom)
        {
            // Set An Enemy In The Individual Room
            Enemies enemy = currentRoom.RoomEnemy;
            Helper.DisplayMessage($"The { enemy.EnemyName } appears \n \n".ToUpper());

            // Checks If Player Has A Weapon In The Inventory
            if (_player.PlayerDamage == 0)
            {
                // Setting Damage To 5, So User Doesn't Feel Helpless, If Weapon Wasn't Found Yet
                _player.PlayerDamage = 5;
            }
            
            // Fighting Loop
            while (true)
            {
                // Player's Turn
                Helper.DisplayMessage($"{_player.PlayerName}'s turn! Press Enter to attack!\n \n".ToUpper());
                Console.ReadLine();
                
                // Damages Enemy
                enemy.EnemyHealth = _player.DamageEnemy(enemy.EnemyHealth, _player.PlayerDamage);

                // Check Whether Enemy Is Dead
                if (enemy.EnemyHealth <= 0)
                {
                    Helper.DisplayMessage("You have defeated the enemy!\n \n".ToUpper());
                    break;
                } else {
                    // Enemy's Turn
                    Helper.DisplayMessage("Enemy's turn...\n \n".ToUpper());
                
                    // Assign Player's New Health Through Damage
                    _player.PlayerHealth = enemy.DamagePlayer(
                        enemy.EnemyDamage,
                        _player.PlayerHealth,
                        enemy.EnemyHealth);
                }
                
                // Confirmation Action
                _story.ConfirmationMessage();
                
                // Check Whether The Player Is Dead
                if (_player.PlayerHealth <= 0)
                {
                    Helper.DisplayMessage("You have been defeated!\n \n".ToUpper());
                    
                    // Confirmation Action
                    _story.ConfirmationMessage();
                    
                    // Finish Game
                    _story.LoseAdventure();
                    
                    // Break The Loop
                    break;
                }
            }
        }
        
        // Enter Fighting Mode Inside The Room
        
        private void EnterFight(Rooms currentRoom)
        {
            // Generates The Enemy
            currentRoom.GenerateRoomEnemy();
            
            // If There Is An Enemy, Then Start Combat
            if (currentRoom.RoomEnemy != null)
            {
                // Summon The Enemy Message Line
                _story.EnemyMessage();
                
                // Confirmation Action
                _story.ConfirmationMessage();
                
                FightEncounter(currentRoom);
            } else {
                Helper.DisplayMessage("There is no enemy, lucky you!\n \n".ToUpper());
            }
        }
        
        /*
         * INVENTORY & ITEMS
         * INVENTORY & ITEMS
         * INVENTORY & ITEMS
         */
        
        // Item Search Action
        private void ItemFound(Rooms currentRoom)
        {
            // Generate Item In The Room
            currentRoom.GenerateRoomItem();
            
            // Check Whether It Exists
            // If It Does, Pick Up
            if (currentRoom.RoomItem != null)
            {
                // Display a Message
                Helper.DisplayMessage("Item found! \n".ToUpper());
                Helper.DisplayMessage($"It's {currentRoom.RoomItem.ItemName} \n \n".ToUpper());
                
                // Item Assignment To Player
                
                // Assign Damage
                _player.PlayerDamage = currentRoom.RoomItem.ItemDamage;
                
                // Assign Item's Name
                _player.PlayerInventoryItem = currentRoom.RoomItem.ItemName;
                
                // Assign New Player Health (If Applicable)
                // Healing
                _player.PlayerHealth += currentRoom.RoomItem.ItemHeal;
                
                // Damaging
                _player.PlayerHealth -= currentRoom.RoomItem.ItemDamage;
                
                // Show Stats
                Helper.DisplayMessage($"Player's Health: {_player.PlayerHealth} \n" +
                                      $"Player's Damage: {_player.PlayerDamage} \n \n");
                
                // Action Confirmation
                _story.ConfirmationMessage();
            } else {
                Helper.DisplayMessage($"There is no item, tough luck, { _player.PlayerName }.\n \n".ToUpper());
            }
        }
        
        /*
         * ROOMS
         * ROOMS
         * ROOMS
         */
        
        // Exit Search Sequence
        private void ExitRoom(Rooms currentRoom)
        {
            // Generate The Exit
            currentRoom.GenerateRoomExit();
            
            // Check If This Exit Exists
            if (currentRoom.RoomExit)
            {
                // Display Message
                Helper.DisplayMessage("Exit Found!\n \n".ToUpper());
                
                // Action Confirmation Message
                _story.ConfirmationMessage();
            } else {
                Helper.DisplayMessage("Well, there is no exit...\n \n".ToUpper());
            }
        }
        
        // Abstract Room Sequence
        private void RoomExec(Rooms currentRoom)
        {
            // Room's Message
            _story.GetRoomDescription();
            
            // Game Loop For Room
            while (true)
            {
                // Load Individual Action In The Room
                AdventureLoad(currentRoom);
                
                // Check Whether Exit Was Found
                if (currentRoom.RoomExit)
                {
                    Helper.DisplayMessage("Proceeding To The Next Room!\n \n".ToUpper());
                    break;
                }
            }
        }
    }
    
}