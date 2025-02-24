namespace DungeonMaster
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

                // Checks
                // Creates New Room Object
                Rooms newRoom1 = new Rooms();

                // End Game Check
                if (_player.PlayerHealth == 0)
                {
                    _story.LoseAdventure();
                }
                else if (newRoom1.ExitFound)
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
                
            }
            
            // Looking For Items
            else if (adventureConfirmation && adventureAction == _story.AdventureActions[1])
            {
                Helper.DisplayMessage("Item Found!".ToUpper());
                _inventory.SetRoomWeapon("Sword", 20);
            }
            
            // Looking For Exit
            else if (adventureConfirmation && adventureAction == _story.AdventureActions[2])
            {
                Console.WriteLine("Empty Action");
            }
            
            // Skip
            else if (adventureConfirmation && adventureAction == _story.AdventureActions[3])
            {
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