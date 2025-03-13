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
        /// <summary>
        /// There Is 1 Global Player, Hence _player Is Set
        /// There Is 1 Related Global Story That Is
        /// Referenced Across All The Files, Hence There Is 1 Public instance _story
        /// </summary>
        
        private Player _player = new Player();
        private Story _story = new Story();
        
        /// <summary>
        /// Game Loop Method
        /// Doesn't take any arguments neither does return any of the data.
        /// Initialises adventure, creates game loop sequence based off of rooms and checks for win in the last room.
        /// </summary>
        
        
        public void Game()
        {
            /// <remarks>
            /// Initialises Adventure
            /// </remarks>
            AdventureInit();
            
            /// <remarks>
            /// Creares room objects
            /// </remarks>
            Rooms room1 = new Rooms();
            RoomExec(room1);
            
            Rooms room2 = new Rooms();
            RoomExec(room2);
            
            Rooms room3 = new Rooms();
            RoomExec(room3);
            
            Rooms room4 = new Rooms();
            RoomExec(room4);
            
            Rooms room5 = new Rooms();
            RoomExec(room5);

            /// <remarks>
            /// Check whether user has won the adventure by finding the exit in the last room
            /// </remarks>
            if (room5.RoomExit)
            {
                _story.WinAdventure();
            }
        }

        /// <summary>
        /// Creates the story sequence inside of the game.
        /// We meed to initialise adventure as well as load it.
        /// </summary>
        
        /// <remarks>
        /// Initialises the adventure.
        /// Runs the story lines first,
        /// Get player's character name,
        /// Confirm name and assign health.
        /// </remarks>
        private void AdventureInit()
        {
            /// <remarks>
            /// Start story
            /// </remarks>
            _story.Welcome();
            _story.StartStory();

            /// <remarks>
            /// Enter player's cahracter name,
            /// And confirm it.
            string characterName = _player.GetCharacterName();
            _story.CharacterNameConfirmation(characterName);
            
            _player.PlayerHealth = 100;
        }

        /// <summary>
        /// Loads current adventure that user is about to take.
        /// Action is generated outside elsewhere in the Story.cs class,
        /// Hence this method selects the randomly generated action.
        /// </summary>
        /// <param name="curentRoom">
        /// Assigns the room to the current parameter of the method, so the adventure is applied to the right room.
        /// </param>
        private void AdventureLoad(Rooms curentRoom)
        {
            /// <remarks>
            /// Setting the adventure actions from Story.cs by applying object of _story.
            /// </remarks>
            _story.SetAdventureActions();
            
            Helper.DisplayMessage($"Now you are neck deep into {_story.AdventureActionName}...\n \n".ToUpper());
            
            /// <remarks>
            /// Selects the random action generated in the story file.
            /// Chooses fighting, item search, exit search and dwelling sequences respectively.
            /// </remarks>
            if (_story.AdventureActionName == _story.AdventureActions[0])
            {
                EnterFight(curentRoom);
            } else if (_story.AdventureActionName == _story.AdventureActions[1]) {
                ItemFound(curentRoom);
            } else if (_story.AdventureActionName == _story.AdventureActions[2]) {
                ExitRoom(curentRoom);
            } else if (_story.AdventureActionName == _story.AdventureActions[3]) {
                _story.DwellingMessages();
            }
        }
        
        /// <summary>
        /// Creates the fighting sequence between the player and randomly selected enemy.
        /// </summary>
        /// <param name="currentRoom">
        /// Passes the room where the encounter happens
        /// </param>
        /// <remarks>
        /// Enemy is assigned to the room where the player is,
        /// And a following message appears in case there is an enemy in the room.
        /// Then player is checked for the damage he has, hence we set the damage to 15 if the item slot is empty.
        /// After checks are complete, we enter the fighting loop, where we use turn-based system for the fight.
        /// Status of health of both player and enemy are displayed.
        /// </remarks>
        private void FightEncounter(Rooms currentRoom)
        {
            /// <remarks>
            /// Sets the individual enemy.
            /// </remarks>
            Enemies enemy = currentRoom.RoomEnemy;
            Helper.DisplayMessage($"The { enemy.EnemyName } appears \n \n".ToUpper());

            /// <remarks>
            /// Checks whether player has a weapon,
            /// If he doesn't, then we set it to basic 15 units of damage.
            /// </remarks>
            if (_player.PlayerDamage == 0)
            {
                _player.PlayerDamage = 15;
            }
            
            /// <remarks>
            /// Fighting Loop
            /// </remarks>
            while (true)
            {
                /// <remarks>
                /// Player's turn, where player is announced and enemy is damaged. Then we check for enemy's death.
                /// </remarks>
                Helper.DisplayMessage($"{_player.PlayerName}'s turn! Press Enter to attack!\n \n".ToUpper());
                Console.ReadLine();
                
                enemy.EnemyHealth = _player.DamageEnemy(enemy.EnemyHealth, _player.PlayerDamage);

                if (enemy.EnemyHealth <= 0)
                {
                    Helper.DisplayMessage("You have defeated the enemy!\n \n".ToUpper());
                    break;
                } else {
                    /// <remarks>
                    /// In case enemy is still alive, return the damage
                    /// </remarks>
                    Helper.DisplayMessage("Enemy's turn...\n \n".ToUpper());
                
                    /// <remarks>
                    /// New health is assigned to the player through enemy's damage.
                    /// health is validate in case player's health goes below 0 and then we kill him later.
                    /// </remarks>
                    /// <param>
                    /// enemy.EnemyDamage,
                    /// _player.PlayerHealth,
                    /// enemy.EnemyHealth
                    /// </param>
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
                    
                    _story.ConfirmationMessage();
                    
                    HealthValidation();
                    
                    break;
                }
            }
        }
        
        /// <summary>
        /// Generates the enemy in the room and checks whether enemy is present in the room in the first place.
        /// In case it is, then combat starts.
        /// </summary>
        /// <param name="currentRoom">currentRoom is passes in order to define the room we are about to use.</param>
        
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
        
        /// <summary>
        /// We are validating the health of the player in order to check whether player is dead or alive.
        /// In case of going below 0 health-wise, we are making it equal to 0, so bugs are prevented.
        /// And then player is killed.
        /// </summary>
        public void HealthValidation()
        {
            if (_player.PlayerHealth <= 0)
            {
                _player.PlayerHealth = 0;
                _story.LoseAdventure();
            }
        }
        
        /// <summary>
        /// Works on the items, where we are looking for the items by generating randomly an item in the room.
        /// When new item is picked up, status is updated.
        /// </summary>
        /// <param name="currentRoom">currentRoom is passes in order to define the room we are about to use.</param>
        private void ItemFound(Rooms currentRoom)
        {
            currentRoom.GenerateRoomItem();
            
            if (currentRoom.RoomItem != null)
            {
                Helper.DisplayMessage("Item found! \n".ToUpper());
                Helper.DisplayMessage($"It's {currentRoom.RoomItem.ItemName} \n \n".ToUpper());
                
                _player.PlayerDamage = currentRoom.RoomItem.ItemDamage;
                
                _player.PlayerInventoryItem = currentRoom.RoomItem.ItemName;
                
                _player.PlayerHealth += currentRoom.RoomItem.ItemHeal;
                
                Helper.DisplayMessage($"Player's Health: {_player.PlayerHealth} \n" +
                                      $"Player's Damage: {_player.PlayerDamage} \n \n");
                
                _story.ConfirmationMessage();
            } else {
                Helper.DisplayMessage($"There is no item, tough luck, { _player.PlayerName }.\n \n".ToUpper());
            }
        }
        
        /// <summary>
        /// Works on the room sequences.
        /// We are creating the exits in the room. In case there is, we show that it is found.
        /// And if there's none, then the following message is displayed.
        /// </summary>
        /// <param name="currentRoom">currentRoom is passes in order to define the room we are about to use.</param>
        private void ExitRoom(Rooms currentRoom)
        {
            currentRoom.GenerateRoomExit();
            
            if (currentRoom.RoomExit == true)
            {
                Helper.DisplayMessage("Exit Found!\n \n".ToUpper());
                
                _story.ConfirmationMessage();
            } else {
                Helper.DisplayMessage("Well, there is no exit...\n \n".ToUpper());
                
                _story.ConfirmationMessage();
            }
        }
        
        /// <summary>
        /// Execute the room sequence, by loading the adventure, checking the health in a loop and then check for win.
        /// </summary>
        /// <param name="currentRoom">currentRoom is passes in order to define the room we are about to use.</param>
        private void RoomExec(Rooms currentRoom)
        {
            // Room's Message
            _story.GetRoomDescription();
            
            while (true)
            {
                AdventureLoad(currentRoom);
                
                HealthValidation();
                
                if (currentRoom.RoomExit == true)
                {
                    Helper.DisplayMessage("Proceeding To The Next Room!\n \n".ToUpper());
                    
                    _story.ConfirmationMessage();
                    break;
                }
            }
        }
    }
}