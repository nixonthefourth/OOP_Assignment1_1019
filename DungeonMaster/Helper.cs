namespace DungeonMaster
{
    public class Helper
    {
        // Typewriter Visual
        public static void DisplayMessage(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(30);
            }
        }
    }
}