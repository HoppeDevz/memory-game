using System;
using System.IO;

using MemoryGamePlayerUtils;

namespace MemGamePlayerController
{
    public class PlayerController
    {

        public bool tryRegisterPlayer(string username, string password)
        {

            bool playerAlreadyExistInDb = PlayerUtils.verifyIfPlayerAlreadyExist(username);

            if (playerAlreadyExistInDb)
                return false;
            

            PlayerUtils.registerPlayerInDatabase(username, password);
            return true;

        }

        public bool tryLogin(string username, string password)
        {

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\memory-game-cs\\playerdb.txt";

            StreamReader buffer = new StreamReader(filePath);

            string line = buffer.ReadLine();

            while (line != null)
            {

                string[] playerData = line.Split('|');

                string playerName = playerData[0];
                string playerPassword = playerData[1];
                double playerScore = double.Parse(playerData[2]);

                if (playerName == username)
                {

                    if (playerPassword != password)
                    {

                        buffer.Close();
                        return false;
                    }



                    buffer.Close();
                    return true;
                }

                line = buffer.ReadLine();
            }

            buffer.Close();
            return false;
        }

        public bool addPlayerScore(string username, double amount)
        {

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\memory-game-cs\\playerdb.txt";

            string[] lines = File.ReadAllLines(filePath);

            int counter = 0;

            foreach (string line in lines)
            {

                string playerName = line.Split('|')[0];
                string playerPassword = line.Split('|')[1];

                if (playerName == username)
                {

                    double playerScore = double.Parse(line.Split('|')[2]);
                    double newScore = playerScore + amount;

                    lines[counter] = playerName + "|" + playerPassword + "|" + newScore.ToString();
                    File.WriteAllLines(filePath, lines);

                    return true;
                }

                counter++;
            }

            return false;
        }
        public double getPlayerScore(string username, string password)
        {

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\memory-game-cs\\playerdb.txt";

            StreamReader buffer = new StreamReader(filePath);

            string line = buffer.ReadLine();

            while (line != null)
            {

                string[] playerData = line.Split('|');

                string playerName = playerData[0];
                string playerPassword = playerData[1];
                double playerScore = double.Parse(playerData[2]);

                if (playerName == username)
                {

                    if (playerPassword != password)
                    {

                        buffer.Close();
                        return -2;
                    }



                    buffer.Close();
                    return playerScore;
                }

                line = buffer.ReadLine();
            }

            buffer.Close();
            return -1;
        }
    }
}
