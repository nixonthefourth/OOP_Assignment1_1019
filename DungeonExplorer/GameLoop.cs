using System.Threading.Channels;

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
            Rooms room1 = new Rooms();
            
            // Rooms Message
            _story.GetRoomDescription();
            
            // Game Loop
            while (true)
            {
                // Load Individual Action In The Room
                AdventureLoad(room1);
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
            }
            
            // Looking For Items
            else if (_story.AdventureActionName == _story.AdventureActions[1])
            {
                // Item Search
                ItemFound(curentRoom);
                
                // Action Confrimation
                _story.ConfirmationMessage();
            }
            
            // Looking For Exit
            else if (_story.AdventureActionName == _story.AdventureActions[2])
            {
                Console.WriteLine("Empty Action \n \n");
                
                // Confirmation Action
                _story.ConfirmationMessage();
            }
            
            // Dwelling
            else if (_story.AdventureActionName == _story.AdventureActions[3])
            {
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
                }

                // If It Isn't, Then Hit Back
                else
                {
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
            }

            // In case there is no enemy
            else
            {
                Helper.DisplayMessage("There is no enemy, lol!\n \n".ToUpper());
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
            }

            // In Case There Is No Item
            else
            {
                Helper.DisplayMessage("There is no item, lol! \n \n".ToUpper());
            }
        }
    }
}