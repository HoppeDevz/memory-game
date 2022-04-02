using System;
using System.IO;

namespace MemoryGamePlayerUtils
{
    public class PlayerUtils
    {


        public static bool playerDatabaseFileExist()
        {

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\memory-game-cs\\playerdb.txt";
            return File.Exists(filePath);
        }

        public static void createPlayerDatabase()
        {

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\memory-game-cs\\playerdb.txt";
            File.Create(filePath);

            Console.WriteLine("[MEMORY-GAME-INFO] Player database has been created!");
        }
    }
}
