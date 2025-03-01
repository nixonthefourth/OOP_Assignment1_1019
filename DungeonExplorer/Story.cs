namespace DungeonExplorer
{
    public class Story
    {
        // Variables
        private bool AdventureConfirmation { get; set; }
        public string AdventureActionName { get; set; }
        public string[] AdventureActions = new string[] { "Fight", "Item Search", "Exit Search", "Dwelling" };
        
        // START OF STORY
        // START OF STORY
        // START OF STORY
        
        // Welcome Message
        public void Welcome()
        {
            Helper.DisplayMessage("Welcome to Dungeon Explorer! \n \n".ToUpper());
        }
        
        // Pre-Story
        public void StartStory()
        {
            // Text Lines
            Helper.DisplayMessage("*** \n".ToUpper());
            Helper.DisplayMessage("Long time ago... \n".ToUpper());
            Helper.DisplayMessage("In a far-far galaxy. \n".ToUpper());
            Helper.DisplayMessage("The son of Biggleswade was born. \n".ToUpper());
            Helper.DisplayMessage("Hence, it's up to a mighty hero to find him. \n".ToUpper());
            Helper.DisplayMessage("*** \n \n".ToUpper());
            
            // Waiting Timer
            System.Threading.Thread.Sleep(3000);
            
            // Clear the Console
            Console.Clear();
        }
        
        // Output Character's Name (Input Confirmation)
        public void CharacterNameConfirmation(string characterName)
        {
            Helper.DisplayMessage($"Welcome, {characterName}. \n \n".ToUpper());
            Console.WriteLine();
            
            // Wait
            System.Threading.Thread.Sleep(3000);
            
            // Clear Console
            Console.Clear();
        }
        
        // USER ACTIONS
        // USER ACTIONS
        // USER ACTIONS
        
        // Get Room Description Confirmation
        public void GetRoomDescription()
        {
            // Clear Console
            Console.Clear();
            
            // Display Message & Get Data
            Helper.DisplayMessage("Would you like to get room description? Y/N ".ToUpper());

            while (true)
            {
                string userResponse = Console.ReadLine().ToLower();
            
                // Checks
                // Yes Case
                if (userResponse == "y")
                {
                    // Display
                    RoomMessages();
                    break;
                }
            
                // No Case
                else if (userResponse == "n")
                {
                    break;
                }

                else
                {
                    Helper.DisplayMessage("Invalid response. Please try again.".ToUpper());
                }
            }
        }
        
        // GAME SEQUENCES
        // GAME SEQUENCES
        // GAME SEQUENCES

        // Set Adventure Actions
        public string SetAdventureActions()
        {
            // Define Random Integers
            Random rnd = new Random();
            int index = rnd.Next(0, 4);
            
            // Assigns a Random Value For The Action
            AdventureActionName = AdventureActions[index];
            
            return AdventureActionName;
        }
        
        // Losing Sequence
        public void LoseAdventure()
        {
            // Clear Previous Lines
            Console.Clear();
            
            // Messages
            Helper.DisplayMessage($"You finished the adventure! \n".ToUpper());
            Helper.DisplayMessage($"By being killed...".ToUpper());
            
            // End Suffering
            Environment.Exit(0);
        }
        
        // Winning Sequence
        public void WinAdventure()
        {
            Helper.DisplayMessage($"You completed the adventure!".ToUpper());
        }
        
        // MESSAGES
        // MESSAGES
        // MESSAGES
        
        // Enemy Messages
        public void EnemyMessage()
        {
            // Variables
            string messagePattern1 = "Shagger!";
            string messagePattern2 = "Frenchie!";
            string messagePattern3 = "What a fool to run on skeleton!";
            string messagePattern4 = "Bare your bones!";
            
            // Set The Random List
            Random rnd = new Random();
        }
        
        // Room Messages
        public void RoomMessages()
        {
            // Set A Random Message For The Room
            Random randomIndex = new Random();

            string roomMessage1 = "You are walking around dark dungeons of Stevenage \n \n";
            string roomMessage2 = "Something has creaked... \n \n";
            string roomMessage3 = "Your wife might call you any time. \n \n";
            
            // Append An Array
            string[] roomMessage = new string[] { roomMessage1, roomMessage2, roomMessage3 };
                
            // Select The Displayed Message Randomly
            Helper.DisplayMessage(roomMessage[randomIndex.Next(roomMessage.Length)].ToUpper());
        }
        
        // Dwelling Messages
        public void DwellingMessages()
        {
            // Set A Random Message For Dwelling
            Random randomIndex = new Random();
            
            string dwellMessage1 = "Thinking about Plato. \n \n";
            string dwellMessage2 = "Answer is 42! \n \n";
            string dwellMessage3 = "Mighty knights might do something tonight. \n \n";
                
            // Append An Array
            string[] dwellMessage = new string[] { dwellMessage1, dwellMessage2, dwellMessage3 };
                
            // Select The Displayed Message Randomly
            Helper.DisplayMessage(dwellMessage[randomIndex.Next(dwellMessage.Length)].ToUpper());
            Helper.DisplayMessage("Press any key to continue... \n \n");
            Console.ReadLine();
        }
    }
}