using System;
using System.IO;
using MemoryGameUtils;

namespace MemoryGamePlayer
{
    public class Player
    {

        private string playerName;
        private string playerPassword;

        private int score;

        public Player(string playerName, string playerPassword)
        {
            this.playerName = playerName;
            this.playerPassword = playerPassword;
            this.score = 0;
        }
    }
}
