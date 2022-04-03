using System;
using System.IO;

namespace MemoryGamePlayer
{
    public class Player
    {

        private string playerName;
        private string playerPassword;

        private double score;

        public Player(string playerName, string playerPassword)
        {

            this.playerName = playerName;
            this.playerPassword = playerPassword;
            this.score = 0;
        }
    }
}
