using System.IO;
using System;

namespace MemoryGameUtils
{
    public class GameUtils
    {

        public static string getApplicationDataDirectory()
        {

            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        public static string getMemoryGameDataDirectory()
        {

            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\memory-game-cs";
        }

        public static void createGameDataFolder()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\memory-game-cs";
            Directory.CreateDirectory(path);

            Console.WriteLine("[MEMORY-GAME-INFO] Game data folder has been created!");
        }

        public static bool gameDataFolderExist()
        {

            return Directory.Exists(

                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\memory-game-cs"
            );
        }
    }
}
