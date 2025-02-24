namespace DungeonMaster
{
    public class Story
    {
        // Variables
        private bool AdventureConfirmation { get; set; }
        public string AdventureActionName { get; set; }
        public string[] AdventureActions = new string[] { "Fight", "Item Search", "Exit Search", "Dwelling" };
        
        // Welcome Message
        public void Welcome()
        {
            Helper.DisplayMessage("Welcome to DungeonMaster! \n \n".ToUpper());
        }
        
        // Pre-Story
        public void StartStory()
        {
            // Text Lines
            Helper.DisplayMessage("*** \n".ToUpper());
            Helper.DisplayMessage("Long time ago... \n".ToUpper());
            Helper.DisplayMessage("In a far-far galaxy. \n".ToUpper());
            Helper.DisplayMessage("The star of all was born. \n".ToUpper());
            Helper.DisplayMessage("Hence, it's up to a mighty hero to find it. \n".ToUpper());
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
        
        // Get User's Confirmation On Any Action
        public bool AdventureAction(string actionName)
        {
            // Input Validation
            while (true)
            {
                // Entry Message
                Helper.DisplayMessage($"Are you ready for {actionName}? Y/N ".ToUpper());
                string adventureConfirmationInput = Console.ReadLine();
                
                // Actual Validator
                if (adventureConfirmationInput.ToLower() == "y")
                {
                    AdventureConfirmation = true;
                    break;
                }
            
                else if  (adventureConfirmationInput.ToLower() == "n")
                {
                    AdventureConfirmation = false;
                    break;
                }

                else
                {
                    Helper.DisplayMessage("Sorry, didn't quite get that \n".ToUpper());
                }
            }
            
            // Return
            return AdventureConfirmation;
        }
        
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
            Helper.DisplayMessage($"You finished the adventure! \n".ToUpper());
            Helper.DisplayMessage($"By being killed...".ToUpper());
        }
        
        // Winning Sequence
        public void WinAdventure()
        {
            Helper.DisplayMessage($"You completed the adventure!".ToUpper());
        }
    }
}