using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    
    public class Story
    {
        /*
         * VARIABLES
         * VARIABLES
         * VARIABLES
         */
        
        // Story
        public string AdventureActionName { get; set; }
        public string[] AdventureActions = new string[] { "Fight", "Item Search", "Exit Search", "Dwelling" };
        
        // System
        
        // Define A Random Seed
        Random _randomInteger = new Random();
        
        /*
         * STORY START
         * STORY START
         * STORY START
         */
        
        // Welcome Message
        public void Welcome()
        {
            Helper.DisplayMessage("Welcome to Dungeon Explorer! \n \n".ToUpper());
            
            // Pressing Enter
            Helper.DisplayMessage("Press Enter to continue... \n \n".ToUpper());
            Console.ReadLine();
            
            // Clear The Console
            Console.Clear();
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
            
            // Pressing Enter
            Helper.DisplayMessage("Press Enter to continue... \n \n".ToUpper());
            Console.ReadLine();
            
            // Clear the Console
            Console.Clear();
        }
        
        // Output Character's Name (Name Confirmation Pretty Much)
        public void CharacterNameConfirmation(string characterName)
        {
            Helper.DisplayMessage($"Welcome, {characterName}. \n \n".ToUpper());
            Console.WriteLine();
            
            // Pressing Enter
            Helper.DisplayMessage("Press Enter to continue... \n \n".ToUpper());
            Console.ReadLine();
            
            // Clear Console
            Console.Clear();
        }
        
        /*
         * USER ACTIONS
         * USER ACTIONS
         * USER ACTIONS
         */
        
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
                    Helper.DisplayMessage("Invalid response. Please try again: ".ToUpper());
                }
            }
        }
        
        /*
         * GAME SEQUENCES
         * GAME SEQUENCES
         * GAME SEQUENCES
         */

        // Set Adventure Actions
        public void SetAdventureActions()
        {
            // Random Index
            int index = _randomInteger.Next(0, 3);
            
            // Assigns a Random Value For The Action
            AdventureActionName = AdventureActions[index];
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
        
        /*
         * MESSAGES
         * MESSAGES
         * MESSAGES
         */
        
        // Enemy Messages
        public void EnemyMessage()
        {
            // Variables
            string messagePattern1 = "Son Of A Bastard! \n";
            string messagePattern2 = "Frenchie! \n";
            string messagePattern3 = "What a fool to run on to me! \n";
            string messagePattern4 = "Bare your bones! \n";
            
            // Append An Array
            string[] enemyMessage = new string[] { messagePattern1, messagePattern2, messagePattern3, messagePattern4 };
                
            // Select The Displayed Message Randomly
            Helper.DisplayMessage(enemyMessage[_randomInteger.Next(enemyMessage.Length)].ToUpper());
        }
        
        // Room Messages
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
        
        // Dwelling Messages
        public void DwellingMessages()
        {
            string dwellMessage1 = "Thinking about Plato. \n \n";
            string dwellMessage2 = "Answer is 42! \n \n";
            string dwellMessage3 = "Mighty knights might do something tonight. \n \n";
                
            // Append An Array
            string[] dwellMessage = new string[] { dwellMessage1, dwellMessage2, dwellMessage3 };
                
            // Select The Displayed Message Randomly
            Helper.DisplayMessage(dwellMessage[_randomInteger.Next(dwellMessage.Length)].ToUpper());
            Helper.DisplayMessage("Press Enter to continue... \n \n".ToUpper());
            Console.ReadLine();
        }
        
        // Confirmation Message
        public void ConfirmationMessage()
        {
            // Showing Confirmation Message
            Helper.DisplayMessage("Press Enter to continue... \n \n".ToUpper());
            Console.ReadLine();
            
            // Clear Previous Lines
            Console.Clear();
        }
    }
}