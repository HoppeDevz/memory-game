using System;

namespace MemoryGameLog
{
    public class GameLog
    {

        public static void log(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[MEMORY-GAME] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
        }

        public static void logColoredTextWithPrefix(string prefix, string text, int color, bool newLine = true)
        {

            ConsoleColor textColor = ConsoleColor.Green;

            switch (color)
            {

                case 1:
                {
                    textColor = ConsoleColor.Green;
                    break;
                }

                case 2:
                {
                    textColor = ConsoleColor.Blue;
                    break;
                }

                case 3:
                {
                    textColor = ConsoleColor.Yellow;
                    break;
                }
            }

            Console.ForegroundColor = textColor;
            Console.Write(prefix);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(text);

            if (newLine)
                Console.WriteLine();
        }

        public static void logColoredText(string text, int color, bool newLine)
        {

            ConsoleColor textColor = ConsoleColor.Green;

            switch (color)
            {

                case 1:
                {
                    textColor = ConsoleColor.Red;
                    break;
                }

                case 2:
                {
                    textColor = ConsoleColor.Yellow;
                    break;
                }

                case 3:
                {
                    textColor = ConsoleColor.Green;
                    break;
                }

                case 4:
                {
                    textColor = ConsoleColor.Blue;
                    break;
                }

                case 5:
                {
                    textColor = ConsoleColor.Magenta;
                    break;
                }
            }

            Console.ForegroundColor = textColor;
 
            if (!newLine)
                Console.Write(text);

            if (newLine)
                Console.WriteLine(text);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
