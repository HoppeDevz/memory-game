using MemoryGamePlayerUtils;
using MemoryGameUtils;

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

        public void initializeGameCore()
        {

            this.verifyGameApplicationData();
            this.verifyPlayerDatabaseFile();
        }
    }
}
