using System;
using System.IO;

using MemoryGameLog;

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

            FileStream fs = File.Create(filePath);
            fs.Close();

            GameLog.log("Player database has been created!");
        }

        public static bool verifyIfPlayerAlreadyExist(string searchPlayerName)
        {

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\memory-game-cs\\playerdb.txt";

            StreamReader buffer = new StreamReader(filePath);

            string line = buffer.ReadLine();

            while (line != null)
            {

                string[] playerData = line.Split('|');

                string playerName = playerData[0];

                if (playerName == searchPlayerName)
                {
                    line = buffer.ReadLine();

                    buffer.Close();
                    return true;
                }

                line = buffer.ReadLine();
            }

            buffer.Close();
            return false;
        }

        public static void registerPlayerInDatabase(string playerName, string playerPassword)
        {

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\memory-game-cs\\playerdb.txt";

            double startScoreValue = 0.0;

            try
            {

                File.AppendAllText(filePath, playerName + "|" + playerPassword + "|" + startScoreValue.ToString() + "\n");

            } catch(Exception error)
            {

                Console.WriteLine(error.Message);
            }
        }
    }
}
