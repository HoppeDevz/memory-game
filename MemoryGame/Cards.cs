using System;

namespace MemoryGameCard
{
    public class Card
    {
        private int number;
        private string color;
        private char suit;

        public static int generateRandomNumber()
        {

            Random randomObj = new Random();

            int randomNumber = randomObj.Next(2, 14);

            return randomNumber;
        }

        public static string getSuitColor(char suit)
        {

            switch (suit)
            {

                case '♠': return "black";
                case '♥': return "red";
                case '♦': return "red";
                case '♣': return "black";

                default: return "black";
            }
        }

        public static char generateRandomSuit()
        {
            Random randomObj = new Random();

            char[] cardSuits = { '♠', '♥', '♦', '♣' };

            int randomNumber = randomObj.Next(0, 4);

            return cardSuits[randomNumber];
        }

        public Card(int number, string color, char suit)
        {
            this.number = number;
            this.color = color;
            this.suit = suit;
        }

        public string getCardColor() => this.color;
        public int getCardNumber() => this.number;
        public char getCardSuit() => this.suit;
    }
}
