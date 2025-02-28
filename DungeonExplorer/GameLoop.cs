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
        
        /*
        Rooms and Enemies Have Singular Instances Due To The testing Purposes.
        This Will Be Changed Later For The Population Purposes.
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

            
            // Works Through While Loop, Unless Player Dies or Finds Exit
            while (true)
            {
                AdventureLoad();
                
                // TODO – Think About Error Checking
                // TODO – Create debug.assert
                
                // Checking Sequence
                // End Game Check
                if (_player.PlayerHealth == 0)
                { 
                    _story.LoseAdventure();
                }
                
                else if (room5.ExitFound)
                {
                    _story.WinAdventure();
                    break;
                }
            }
        }

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

                Console.WriteLine("Empty Action");
            }
            
            // Looking For Items
            else if (adventureConfirmation && adventureAction == _story.AdventureActions[1])
            {
                // Clear Previous Lines
                Console.Clear();

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
    }
}