namespace DungeonExplorer
{
    
    public class Story
    {
        public string AdventureActionName { get; set; }
        public string[] AdventureActions = new string[] { "Fight", "Item Search", "Exit Search", "Dwelling" };
        private Random _randomInteger = new Random();
        
        /// <summary>
        /// Display a welcome message
        /// </summary>
        public void Welcome()
        {
            Helper.DisplayMessage("Welcome to Dungeon Explorer! \n \n".ToUpper());
            Helper.DisplayMessage("Press Enter to continue... \n \n".ToUpper());
            Console.ReadLine();
            
            Console.Clear();
        }
        
        /// <summary>
        /// Display the start of the story
        /// </summary>
        public void StartStory()
        {
            Helper.DisplayMessage("*** \n".ToUpper());
            Helper.DisplayMessage("Long time ago... \n".ToUpper());
            Helper.DisplayMessage("In a far-far galaxy. \n".ToUpper());
            Helper.DisplayMessage("The son of Biggleswade was born. \n".ToUpper());
            Helper.DisplayMessage("Hence, it's up to a mighty hero to find him. \n".ToUpper());
            Helper.DisplayMessage("*** \n \n".ToUpper());
            
            Helper.DisplayMessage("Press Enter to continue... \n \n".ToUpper());
            Console.ReadLine();
            
            Console.Clear();
        }
        
        /// <summary>
        /// Output Character's Name (Name Confirmation Pretty Much)
        /// </summary>
        /// <param name="characterName">Pushes the name of the character that player defines.</param>
        public void CharacterNameConfirmation(string characterName)
        {
            Helper.DisplayMessage($"Welcome, {characterName}. \n \n".ToUpper());
            Console.WriteLine();
            
            Helper.DisplayMessage("Press Enter to continue... \n \n".ToUpper());
            Console.ReadLine();
            
            Console.Clear();
        }
        
        /// <summary>
        /// Shows the description of the room with randomly selected values
        /// </summary>
        public void GetRoomDescription()
        {
            Console.Clear();
            
            Helper.DisplayMessage("Would you like to get room description? Y/N ".ToUpper());

            while (true)
            {
                string userResponse = Console.ReadLine().ToLower();
            
                if (userResponse == "y")
                {
                    RoomMessages();
                    break;
                } else if (userResponse == "n") {
                    break;
                } else {
                    Helper.DisplayMessage("Invalid response. Please try again: ".ToUpper());
                }
            }
        }
        
        /// <summary>
        /// Sets the actions we are about to take from the adventures.
        /// </summary>
        public void SetAdventureActions()
        {
            int index = _randomInteger.Next(0, 3);
            
            AdventureActionName = AdventureActions[index];
        }
        
        /// <summary>
        /// If user loses the adventure.
        /// </summary>
        public void LoseAdventure()
        {
            Console.Clear();
            
            Helper.DisplayMessage($"You finished the adventure! \n".ToUpper());
            Helper.DisplayMessage($"By being dying...".ToUpper());
            
            Environment.Exit(0);
        }
        
        /// <summary>
        /// Wins adventure.
        /// </summary>
        public void WinAdventure()
        {
            Helper.DisplayMessage($"You completed the adventure!".ToUpper());
        }
        
        /// <summary>
        /// Messages that enemies say
        /// </summary>
        public void EnemyMessage()
        {
            string messagePattern1 = "Son Of A Bastard! \n";
            string messagePattern2 = "Frenchie! \n";
            string messagePattern3 = "What a fool to run on to me! \n";
            string messagePattern4 = "Bare your bones! \n";
            
            string[] enemyMessage = new string[] { messagePattern1, messagePattern2, messagePattern3, messagePattern4 };
                
            Helper.DisplayMessage(enemyMessage[_randomInteger.Next(enemyMessage.Length)].ToUpper());
        }
        
        /// <summary>
        /// Room description messages
        /// </summary>
        public void RoomMessages()
        {
            string roomMessage1 = "You are walking around dark dungeons of Stevenage.\n \n";
            string roomMessage2 = "Something has creaked...\n \n";
            string roomMessage3 = "This rooms smells like rats in the days of Isaac Newton\n \n";
            
            // Append An Array
            string[] roomMessage = new string[] { roomMessage1, roomMessage2, roomMessage3 };
                
            // Select The Displayed Message Randomly
            Helper.DisplayMessage(roomMessage[_randomInteger.Next(roomMessage.Length)].ToUpper());
        }
        
        /// <summary>
        /// Dwelling description messages
        /// </summary>
        public void DwellingMessages()
        {
            string dwellMessage1 = "Thinking about Plato. \n \n";
            string dwellMessage2 = "Answer is 42! \n \n";
            string dwellMessage3 = "Mighty knights might do something tonight. \n \n";
                
            string[] dwellMessage = new string[] { dwellMessage1, dwellMessage2, dwellMessage3 };
                
            Helper.DisplayMessage(dwellMessage[_randomInteger.Next(dwellMessage.Length)].ToUpper());
            Helper.DisplayMessage("Press Enter to continue... \n \n".ToUpper());
            Console.ReadLine();
        }
        
        /// <summary>
        /// Confirmation sequence (Press enter)
        /// </summary>
        public void ConfirmationMessage()
        {
            Helper.DisplayMessage("Press Enter to continue... \n \n".ToUpper());
            Console.ReadLine();
            
            Console.Clear();
        }
    }
}