namespace DungeonMaster
{
    public class GameFunctions
    {
        // Typewriter Effect
        public void DisplayMessage(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(30);
            }
        }
    }
}