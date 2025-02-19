namespace DungeonMaster
{
    public class GameLoop
    {
        Player _player = new Player();
        Story _story = new Story();
        Rooms _rooms = new Rooms();
        
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

        private void AdventureLoad()
        {
            // Select Event In The Game
            string adventureAction = _story.SetAdventureActions();
            _story.AdventureAction(adventureAction);
        }
    }
}