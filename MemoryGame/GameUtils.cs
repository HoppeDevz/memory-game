using System.IO;
using System;

using MemoryGameLog;

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

        public static bool gameSettingsFileExist()
        {

            return File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\memory-game-cs\\game_settings.txt");
        }

        public static void createGameSettingsFile()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\memory-game-cs\\game_settings.txt";

            FileStream fs = File.Create(filePath);

            fs.Close();
        }

        public static void setDefaultSettings()
        {

            string[] defaultSettings = new string[2]
            {
                "matrix_size|4",
                "decrease_multiplier|0.01",
            };

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\memory-game-cs\\game_settings.txt";

            File.WriteAllLines(filePath, defaultSettings);
        }

        public static int getMatrixSize()
        {

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\memory-game-cs\\game_settings.txt";

            string[] lines = File.ReadAllLines(filePath);

            foreach ( string line in lines )
            {
                string key = line.Split('|')[0];

                if (key == "matrix_size")
                {

                    return int.Parse(line.Split('|')[1]);
                }
            }

            return 0;
        }

        public static bool setMatrixSize(int newValue)
        {

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\memory-game-cs\\game_settings.txt";

            string[] lines = File.ReadAllLines(filePath);

            int counter = 0;

            foreach (string line in lines)
            {
                string key = line.Split('|')[0];

                if (key == "matrix_size")
                {

                    lines[counter] = "matrix_size|" + newValue.ToString();
                    File.WriteAllLines(filePath, lines);

                    return true;
                }

                counter++;
            }

            return false;
        }
        public static bool setDecreaseMultiplier(double newValue)
        {

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\memory-game-cs\\game_settings.txt";

            string[] lines = File.ReadAllLines(filePath);

            int counter = 0;

            foreach (string line in lines)
            {
                string key = line.Split('|')[0];

                if (key == "decrease_multiplier")
                {

                    lines[counter] = "decrease_multiplier|" + newValue.ToString();
                    File.WriteAllLines(filePath, lines);

                    return true;
                }

                counter++;
            }

            return false;
        }


        public static double getDecreaseMultiplier()
        {

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\memory-game-cs\\game_settings.txt";

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string key = line.Split('|')[0];

                if (key == "decrease_multiplier")
                {

                    return double.Parse(line.Split('|')[1]);
                }
            }

            return 0.01;
        }

        public static void createGameDataFolder()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\memory-game-cs";
            Directory.CreateDirectory(path);

            GameLog.log("Game data folder has been created!");
        }

        public static bool gameDataFolderExist()
        {

            return Directory.Exists(

                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\memory-game-cs"
            );
        }
    }
}
