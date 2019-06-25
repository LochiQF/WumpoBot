

namespace WumpoBot
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var wumpoBot = new Bot())
            {
                wumpoBot.RunAsync().Wait();
            }
        }
    }
}
