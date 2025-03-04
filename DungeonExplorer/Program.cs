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
            
            // Actual Game Start
            startGame.Game();
        }
    }
}