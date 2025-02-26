namespace DungeonExplorer
{
    public class GameLoop
    {
        Player _player = new Player();
        Story _story = new Story();
        Rooms _rooms = new Rooms();
        Inventory _inventory = new Inventory();
        Enemies _enemy = new Enemies();
        
        // Game Loop
        public void Game()
        {
            // Initialises Adventure
            AdventureInit();
            
            // Works Through While Loop, Unless Player Dies or Finds Exit
            while (true)
            {
                AdventureLoad();

                // TODO – Create 5 Instances Of Room.cs
                // TODO – Link Rooms.cs
                
                // TODO – Think About Error Checking
                // Checking Sequence
                // End Game Check
                if (_player.PlayerHealth == 0)
                { 
                    _story.LoseAdventure();
                }
                
                else if (_rooms.ExitFound)
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
                
                // Set Player's Weapon
                string userWeapon = _inventory.GetWeaponName();
                _player.SetPlayerDamage(userWeapon);
            }
            
            // Looking For Items
            else if (adventureConfirmation && adventureAction == _story.AdventureActions[1])
            {
                // Clear Previous Lines
                Console.Clear();
                
                Helper.DisplayMessage("Item Found!".ToUpper());
                _inventory.SetRoomWeapon("Sword");
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
                
                // Set A Random Message For Dwelling
                Random randomIndex = new Random();
                string dwellMessage1 = "Thinking about Plato. \n \n";
                string dwellMessage2 = "Answer is 42! \n \n";
                string dwellMessage3 = "Mighty knights might do something tonight. \n \n";
                
                // Append An Array
                string[] dwellMessage = new string[] { dwellMessage1, dwellMessage2, dwellMessage3 };
                
                // Select The Displayed Message
                Helper.DisplayMessage(dwellMessage[randomIndex.Next(dwellMessage.Length)].ToUpper());
            }
        }
    }
}