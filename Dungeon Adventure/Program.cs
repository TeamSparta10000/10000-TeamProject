using Dungeon_Adventure;
namespace Dungeon_Adventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameData.GameDataSetting();
            Scene.DisplayGameStart();
            Scene.DisplayTown();
        }

        public static void ToggleEqupStatus(int idx)
        {
            GameData.items[idx].IsEquipped = !GameData.items[idx].IsEquipped;
        }

        public static void ShowHighlightText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void PrintTextWithHighlights(string s1, string s2, string s3 = "")
        {
            Console.Write(s1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(s2);
            Console.ResetColor();
            Console.WriteLine(s3);
        }
        public static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }

    }


}