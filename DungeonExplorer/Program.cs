using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // Create Main Classes For Game & Testing
            GameLoop startGame = new GameLoop();
            Testing testingSequence = new Testing();
            
            // Run Test Assertions
            testingSequence.RunPlayerTests();
            testingSequence.RunDamageTests();
            testingSequence.RunRoomTests();
            
            // Actual Game Start
            startGame.Game();
        }
    }
}