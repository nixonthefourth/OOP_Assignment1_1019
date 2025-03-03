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
        
        Player _player = new Player();
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

        // Starting Sequence Of The Adventure
        public void AdventureInit()
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
            Helper.DisplayMessage("Press Enter to continue... \n \n".ToUpper());
            Console.ReadLine();
            
            // Clear Previous Lines
            Console.Clear();

            // Checks The Action That May Happen In The Selected Adventure Action
            
            // Fight
            if (_story.AdventureActionName == _story.AdventureActions[0])
            {
                // Action Itself
                EnterFightRoom(curentRoom);
                
                // Showing Confirmation Message
                Helper.DisplayMessage("Press Enter to continue... \n \n".ToUpper());
                Console.ReadLine();
            
                // Clear Previous Lines
                Console.Clear();
            }
            
            // Looking For Items
            else if (_story.AdventureActionName == _story.AdventureActions[1])
            {
                // TODO – Add Item Lookup
                Console.WriteLine("Empty Action \n \n");
                
                // Showing Confirmation Message
                Helper.DisplayMessage("Press Enter to continue... \n \n".ToUpper());
                Console.ReadLine();
            
                // Clear Previous Lines
                Console.Clear();
            }
            
            // Looking For Exit
            else if (_story.AdventureActionName == _story.AdventureActions[2])
            {
                Console.WriteLine("Empty Action \n \n");
                
                // Showing Confirmation Message
                Helper.DisplayMessage("Press Enter to continue... \n \n".ToUpper());
                Console.ReadLine();
            
                // Clear Previous Lines
                Console.Clear();
            }
            
            // Dwelling
            else if (_story.AdventureActionName == _story.AdventureActions[3])
            {
                // Call Messages
                _story.DwellingMessages();
                
                // Showing Confirmation Message
                Helper.DisplayMessage("Press Enter to continue... \n \n".ToUpper());
                Console.ReadLine();
            
                // Clear Previous Lines
                Console.Clear();
            }
        }
        
        // Fighting Sequence
        public void FightEncounter(Rooms currentRoom)
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
            
            // Set Player's Damage To The Selected Item (Testing Purposes, Since Item Search Hasn't Been Implemented Yet)
            _player.PickPlayerItem("Sword");
            
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
                
                // Action Confirmation
                Helper.DisplayMessage("Press Enter to continue... \n \n".ToUpper());
                Console.ReadLine();
                
                // Clear Lines
                Console.Clear();
                
                // Check Whether The Player Is Dead
                if (_player.PlayerHealth <= 0)
                {
                    Helper.DisplayMessage("You have been defeated!\n \n".ToUpper());
                    // Action Confirmation
                    Helper.DisplayMessage("Press Enter to continue... \n \n".ToUpper());
                    Console.ReadLine();
                
                    // Clear Lines
                    Console.Clear();
                    
                    // Finish Game
                    _story.LoseAdventure();
                    
                    // Break The Loop
                    break;
                }
            }
        }
        
        // Enter Fighting Room
        public void EnterFightRoom(Rooms currenRoom)
        {
            // Generates The Enemy
            currenRoom.GenerateRoomEnemy();
            
            // If There Is An Enemy, Then Start Combat
            if (currenRoom.RoomEnemy != null)
            {
                // Summon The Enemy Message Line
                _story.EnemyMessage();
                
                // Action Confirmation
                Helper.DisplayMessage("Press Enter to continue... \n \n".ToUpper());
                Console.ReadLine();
                
                // Clear Lines For Future Clarity
                Console.Clear();
                
                FightEncounter(currenRoom);
            }

            // In case there is no enemy
            else
            {
                Helper.DisplayMessage("There is no enemy, lol!\n \n".ToUpper());
            }
        }
    }
}