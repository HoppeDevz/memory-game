using System;
using System.Threading;

using MemoryGamePlayerUtils;
using MemoryGameUtils;
using MemoryGameLog;

namespace MemoryGameCore
{
    public class Core
    {

        private void verifyGameApplicationData()
        {

            if (!GameUtils.gameDataFolderExist())
                GameUtils.createGameDataFolder();
        }

        private void verifyPlayerDatabaseFile()
        {

            if (!PlayerUtils.playerDatabaseFileExist())
                PlayerUtils.createPlayerDatabase();
        }

        private void verifyGameSettingsFile()
        {

            if (!GameUtils.gameSettingsFileExist()) { 

                GameUtils.createGameSettingsFile();
                GameUtils.setDefaultSettings();
            }
        }

        public bool initializeGameCore()
        {

            GameLog.log("Verifying game files...");

            this.verifyGameApplicationData();
            this.verifyPlayerDatabaseFile();
            this.verifyGameSettingsFile();

            Thread.Sleep(3500);

            GameLog.log("Game loaded!");

            Thread.Sleep(500);

            Console.Clear();

            return true;
        }
    }
}
