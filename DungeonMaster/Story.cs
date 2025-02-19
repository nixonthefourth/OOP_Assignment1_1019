namespace DungeonMaster
{
    public class Story
    {
        // Variables
        private bool AdventureConfirmation { get; set; }
        public string AdventureActionName { get; set; }
        
        // Welcome Message
        public void Welcome()
        {
            Helper.DisplayMessage("Welcome to DungeonMaster!".ToUpper());
            Console.WriteLine();
        }
        
        // Pre-Story
        public void StartStory()
        {
            // Text Lines
            Helper.DisplayMessage("***".ToUpper());
            Helper.DisplayMessage("Long time ago...".ToUpper());
            Helper.DisplayMessage("In a far-far galaxy.".ToUpper());
            Helper.DisplayMessage("The star of all was born.".ToUpper());
            Helper.DisplayMessage("Hence, it's up to a mighty hero to find it.".ToUpper());
            Helper.DisplayMessage("***".ToUpper());
            
            // Waiting Timer
            System.Threading.Thread.Sleep(300);
            
            // Clear the Console
            Console.Clear();
        }
        
        // Output Character's Name (Input Confirmation)
        public void CharacterNameConfirmation(string characterName)
        {
            Helper.DisplayMessage($"Welcome, {characterName}.".ToUpper());
        }
        
        // Get User's Confirmation On Any Action
        public bool AdventureAction(string actionName)
        {
            // Input Validation
            while (true)
            {
                // Entry Message
                Helper.DisplayMessage($"Are you ready for {actionName}? Y/N".ToUpper());
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
                    Helper.DisplayMessage("Sorry, didn't quite get that".ToUpper());
                    AdventureConfirmation = false;
                }
            }
            
            // Return
            return AdventureConfirmation;
        }
    }
}