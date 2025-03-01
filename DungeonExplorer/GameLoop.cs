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
        
        // Game Loop
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

        // Initialising Adventure
        public void AdventureInit()
        {
            // Intro To The Adventure
            
            _story.Welcome();
            _story.StartStory();

            // Confirm Character's Name
            string characterName = _player.GetCharacterName();
            _story.CharacterNameConfirmation(characterName);
            
            // Set Player's Health
            _player.SetPlayerHealth(100);
        }

        // Loads The Adventure Into Code, So It's Selected Later
        private void AdventureLoad(Rooms curentRoom)
        {
            // Select Event In The Game
            string adventureAction = _story.SetAdventureActions();
            Helper.DisplayMessage($"Now you are neck deep into {adventureAction} \n \n".ToUpper());
            Helper.DisplayMessage("Press any key to continue... \n \n".ToUpper());
            Console.ReadLine();

            // Checks The Action That May Happen In The Selected Adventure Action
            
            // Fight
            if (adventureAction == _story.AdventureActions[0])
            {
                // Clear Previous Lines
                Console.Clear();
                
                // Action Itself
                EnterFightRoom(curentRoom);
            }
            
            // Looking For Items
            else if (adventureAction == _story.AdventureActions[1])
            {
                // Clear Previous Lines
                Console.Clear();

                // TODO – Add Item Lookup
                Console.WriteLine("Empty Action \n \n");
            }
            
            // Looking For Exit
            else if (adventureAction == _story.AdventureActions[2])
            {
                // Clear Previous Lines
                Console.Clear();
                
                Console.WriteLine("Empty Action \n \n");
            }
            
            // Dwelling
            else if (adventureAction == _story.AdventureActions[3])
            {
                // Clear Previous Lines
                Console.Clear();
                
                // Call Messages
                _story.DwellingMessages();
            }
        }
        
        // Fighting Sequence
        public void FightEncounter(Rooms currentRoom)
        {
            // Display The Entry Message
            // Check If The Room Has An Enemy First
            if (currentRoom.GetRoomEnemy() == null)
            {
                Helper.DisplayMessage("Room seems really empty...".ToUpper());
            }

            // Set An Enemy In The Individual Room
            Enemies enemy = currentRoom.GetRoomEnemy();
            Helper.DisplayMessage($"The { enemy.EnemyName } appears \n \n".ToUpper());

            // Checks If Player Has An Item In The Inventory
            if (_player.PlayerDamage == 0)
            {
                _player.SetPlayerDamage();
            }
            
            // Set Player's Damage To The Selected Item (Testing Purposes)
            _player.PickPlayerItem("Sword");
            
            // Fighting Loop
            while (_player.PlayerHealth > 0 && enemy.EnemyHealth > 0)
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
                }

                // If It Isn't, Then Hit Back
                else
                {
                    // Enemy's Turn
                    Helper.DisplayMessage("Enemy's turn...\n \n".ToUpper());
                
                    // Assign Player's New Health
                    int playerHealth = _player.SetPlayerHealth(
                        enemy.DamagePlayer(
                            enemy.EnemyDamage, 
                            _player.PlayerHealth, 
                            enemy.EnemyHealth)
                    );

                }
                // Check Whether The Player Is Dead
                if (_player.PlayerHealth <= 0)
                {
                    Helper.DisplayMessage("You have been defeated!\n \n".ToUpper());
                    _story.LoseAdventure();
                }
            }
        }
        
        // Enter Fighting Room
        public void EnterFightRoom(Rooms currenRoom)
        {
            currenRoom.GenerateRoomEnemy();
            
            // If There Is An Enemy, Then Start Combat
            if (currenRoom.GetRoomEnemy() != null)
            {
                // Summon The Enemy Message Line
                _story.EnemyMessage();
                
                FightEncounter(currenRoom);
            }
        }
    }
}