namespace DungeonExplorer
{
    
    public class Helper
    {
        /// <summary>
        /// Displays the chosen strings into the console using terminal visuals.
        /// </summary>
        /// <param name="message"></param>
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