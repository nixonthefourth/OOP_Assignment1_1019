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
        Story _story = new Story();
        Enemies _enemy = new Enemies();
        
        // Game Loop
        public void Game()
        {
            // Initialises Adventure
            AdventureInit();
            
            // TODO – Link Rooms.cs Somehow
            
            // Creating Rooms
            Rooms room1 = new Rooms();
            Rooms room2 = new Rooms();
            Rooms room3 = new Rooms();
            Rooms room4 = new Rooms();
            
            // This Room Is Universally Set To Be The One With An Exit
            Rooms room5 = new Rooms();
            
            // Game Loop
            while (true)
            {
                // Load Individual Action In The Room
                AdventureLoad();
                
                // TODO – Think About Error Checking
                // TODO – Create debug.assert
                // TODO – Create Fighting System
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
        private void AdventureLoad()
        {
            // Select Event In The Game
            string adventureAction = _story.SetAdventureActions();
            bool adventureConfirmation = _story.AdventureAction(adventureAction);

            // Checks The Action That May Happen In The Selected Adventure Action
            
            // Fight
            if (adventureConfirmation && adventureAction == _story.AdventureActions[0])
            {
                // Clear Previous Lines
                Console.Clear();

                // Get Into a Fight
                FightEncounter();
            }
            
            // Looking For Items
            else if (adventureConfirmation && adventureAction == _story.AdventureActions[1])
            {
                // Clear Previous Lines
                Console.Clear();

                // TODO – Add Item Lookup
                Console.WriteLine("Empty Action");
            }
            
            // Looking For Exit
            else if (adventureConfirmation && adventureAction == _story.AdventureActions[2])
            {
                // Clear Previous Lines
                Console.Clear();
                
                Console.WriteLine("Empty Action");
            }
            
            // Dwelling
            else if (adventureConfirmation && adventureAction == _story.AdventureActions[3])
            {
                // Clear Previous Lines
                Console.Clear();
                
                // Call Messages
                _story.DwellingMessages();
            }
        }
        
        // Fighting Sequence
        public void FightEncounter()
        {
            // Display The Entry Message
            Helper.DisplayMessage("Los Bastardos Appears! \n \n".ToUpper());

            // Set An Enemy
            _enemy.SetEnemyHealth();
            _enemy.EnemyDamage = 15;

            // Checks If Player Has An Item In The Inventory
            if (_player.PlayerDamage == 0)
            {
                _player.SetPlayerDamage();
            }
            
            // Set Player's Damage To The Selected Item (Testing Purposes)
            _player.PickPlayerItem("Sword");
            
            // Fighting Loop
            while (_player.PlayerHealth > 0 && _enemy.EnemyHealth > 0)
            {
                // Player's Turn
                Helper.DisplayMessage($"{_player.PlayerName}'s turn! Press Enter to attack!\n \n".ToUpper());
                Console.ReadLine();
                
                // Damages Enemy
                _enemy.EnemyHealth = _player.DamageEnemy(_enemy.EnemyHealth, _player.PlayerDamage);

                // Check Whether Enemy Is Dead
                if (_enemy.EnemyHealth <= 0)
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
                        _enemy.DamagePlayer(
                            _enemy.EnemyDamage, 
                            _player.PlayerHealth, 
                            _enemy.EnemyHealth)
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
    }
}