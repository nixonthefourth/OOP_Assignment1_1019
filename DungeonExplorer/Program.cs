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
        /// <summary>
        ///  Entry point that initialises program with the game loop and testing.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /// <remarks>
            /// Define objects of the game loop and testing prior to the game loop
            /// </remarks>
            GameLoop startGame = new GameLoop();
            Testing testingSequence = new Testing();
            
            
            /// <remarks>
            /// Run test sequences
            /// </remarks>
            testingSequence.RunPlayerTests();
            testingSequence.RunRoomTests();
            
            /// <remarks>
            /// Actual game start
            /// </remarks>
            startGame.Game();
        }
    }
}