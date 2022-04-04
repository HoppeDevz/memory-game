using System;
using System.Threading;

using MemoryGameLog;
using MemGamePlayerController;
using MemoryGameCard;

namespace MemoryGamePlay
{
    public class MemGame
    {

        private string currentPlayerName;
        private string currentPlayerPassword;
        private double currentPlayerScore;

        private int currentGameMatrixSize = MemoryGameUtils.GameUtils.getMatrixSize();
        private double currentGameDecreaseMultiplier = MemoryGameUtils.GameUtils.getDecreaseMultiplier();

        private Card[,] cardsMatrix = new Card[MemoryGameUtils.GameUtils.getMatrixSize(), MemoryGameUtils.GameUtils.getMatrixSize()];

        private PlayerController plyController = new PlayerController();

        private bool userLogged = false;
        private bool matrixCreated = false;
        private bool matchedCardsMatrixCreated = false;

        private int currentGameState = 0;

        private int[][] currentSelectedCards = new int[][] { 
            new int[] { -1, -1}, 
            new int[] { -1, -1 } 
        };

        private int[][] cardsMatched = new int[MemoryGameUtils.GameUtils.getMatrixSize() * MemoryGameUtils.GameUtils.getMatrixSize()][];

        private int numberOfSteps = 0;
        private double currentGameScore = MemoryGameUtils.GameUtils.getMatrixSize();

        bool gameFinished = false;

        private bool tryLogin()
        {

            PlayerController plyController = new PlayerController();

            string username;
            string password;

            GameLog.logColoredTextWithPrefix("[AUTH-SYSTEM] ", "Digite o username: ", 1, false);
            username = Console.ReadLine();

            GameLog.logColoredTextWithPrefix("[AUTH-SYSTEM] ", "Digite a senha: ", 1, false);
            password = Console.ReadLine();

            bool authSuccess = plyController.tryLogin(username, password);

            if (!authSuccess)
            {

                char option;

                GameLog.logColoredTextWithPrefix("[AUTH-SYSTEM] ", "Credenciais incorretas, deseja tentar novamente? y/N ", 3, false);
                option = char.Parse(Console.ReadLine());

                if (option == 'y')
                {

                    Console.Clear();
                    return this.tryLogin();
                }
            }

            if (authSuccess) {

                this.currentPlayerName = username;
                this.currentPlayerPassword = password;
                this.currentPlayerScore = plyController.getPlayerScore(username, password);

                return true;
            }

            // WARNING OF RETURN PATHS
            return false;
        }

        public void renderHorizontalLineOfCards(int unicodeChar, int row)
        {

            for (int i = 0; i < currentGameMatrixSize; i++)
            {

                bool isSelectedCard = row == this.currentSelectedCards[0][0] && i == this.currentSelectedCards[0][1] || row == this.currentSelectedCards[1][0] && i == this.currentSelectedCards[1][1];
                bool isMatchedCard = verifyMatchedCard(row, i);

                if (isSelectedCard)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                if (isMatchedCard)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }


                if (i == 0)
                {
                    Console.Write("   " + (char)unicodeChar + (char)unicodeChar + (char)unicodeChar + (char)unicodeChar + (char)unicodeChar + " ");
                }

                if (i > 0)
                {

                    Console.Write("     " + (char)unicodeChar + (char)unicodeChar + (char)unicodeChar + (char)unicodeChar + (char)unicodeChar + " ");
                }

                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
        }

        void renderGameBanner()
        {

            Console.WriteLine();
            Console.WriteLine("  ███╗   ███╗███████╗███╗   ███╗       ██████╗  █████╗ ███╗   ███╗███████╗");
            Console.WriteLine("  ████╗ ████║██╔════╝████╗ ████║      ██╔════╝ ██╔══██╗████╗ ████║██╔════╝");
            Console.WriteLine("  ██╔████╔██║█████╗  ██╔████╔██║█████╗██║  ███╗███████║██╔████╔██║█████╗  ");
            Console.WriteLine("  ██║╚██╔╝██║██╔══╝  ██║╚██╔╝██║╚════╝██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  ");
            Console.WriteLine("  ██║ ╚═╝ ██║███████╗██║ ╚═╝ ██║      ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗");
            Console.WriteLine("  ╚═╝     ╚═╝╚══════╝╚═╝     ╚═╝       ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝");
            Console.WriteLine();
        }

        void renderCards()
        {

            for (int i = 0; i < currentGameMatrixSize; i++)
            {
                // DRAW HORIZONTAL TOP LINES
                this.renderHorizontalLineOfCards((int)'_', i);

                for (int j = 0; j < currentGameMatrixSize; j++)
                {

                    string formattedI = i < 10 ? '0' + i.ToString() : i.ToString();
                    string formattedJ = j < 10 ? '0' + j.ToString() : j.ToString();

                    bool isSelectedCard = i == this.currentSelectedCards[0][0] && j == this.currentSelectedCards[0][1] || i == this.currentSelectedCards[1][0] && j == this.currentSelectedCards[1][1];
                    bool isMatchedCard = verifyMatchedCard(i, j);

                    // DRAW START VERTICAL LINE
                    if (isSelectedCard)
                        Console.ForegroundColor = ConsoleColor.Green;

                    if (isMatchedCard)
                        Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Write("  |");
                    Console.ForegroundColor = ConsoleColor.White;

                    // DRAW CART I AND J MATRIX INDEX OR CARD INFOS
                    if (isSelectedCard) {

                        int cardNumber = this.cardsMatrix[i, j].getCardNumber();
                        string formattedCardNumber = cardNumber < 10 ? '0' + cardNumber.ToString() : cardNumber.ToString();

                        Console.Write(formattedCardNumber + ", " + this.cardsMatrix[i, j].getCardSuit().ToString());
                    }

                    if (isMatchedCard)
                    {

                        int cardNumber = this.cardsMatrix[i, j].getCardNumber();
                        string formattedCardNumber = cardNumber < 10 ? '0' + cardNumber.ToString() : cardNumber.ToString();

                        Console.Write(formattedCardNumber + ", " + this.cardsMatrix[i, j].getCardSuit().ToString());
                    }

                    if (!isSelectedCard && !isMatchedCard)
                    {
                        Console.Write(formattedI + "," + formattedJ);
                    }
                        

                    // DRAW FINAL VERTICAL LINE
                    if (isSelectedCard)
                        Console.ForegroundColor = ConsoleColor.Green;

                    if (isMatchedCard)
                        Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Write("|  ");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                // NEW LINE TO DRAW BOTTOM LINES
                Console.WriteLine();

                // DRAW HORIZONTAL BOTTOM LINES
                this.renderHorizontalLineOfCards(0x305, i);

                // NEW LINE TO DRAW NEXT ROW OF CARDS
                Console.WriteLine();

            }
        }

        void renderGameInfos()
        {

            Console.WriteLine("  Jogador: " + this.currentPlayerName.ToString());
            Console.WriteLine("  Tentativas: " + this.numberOfSteps.ToString());
            Console.WriteLine("  Score: " + this.currentGameScore.ToString());
        }

        bool verifyCardIndexPosition(string strIndex)
        {   

            try
            {

                string[] splitted = strIndex.Split(',');

                int row = int.Parse(splitted[0]);
                int col = int.Parse(splitted[1]);

                bool isValidRowAmount =
                    row >= 0 &&
                    row < this.currentGameMatrixSize;

                bool isValidColAmount =
                    col >= 0 &&
                    col < this.currentGameMatrixSize;

                bool isSelectedCard =
                    row == this.currentSelectedCards[0][0] && col == this.currentSelectedCards[0][1] ||
                    row == this.currentSelectedCards[1][0] && col == this.currentSelectedCards[1][1];

                return isValidRowAmount && isValidColAmount && !isSelectedCard;

            } catch(Exception error)
            {

                return false;
            }

        }

        bool clearCurrentSelectedCards()
        {

            this.currentSelectedCards[0][0] = -1;
            this.currentSelectedCards[0][1] = -1;

            this.currentSelectedCards[1][0] = -1;
            this.currentSelectedCards[1][1] = -1;

            return true;
        }

        bool createMatchedCardsArray()
        {
            
            for (int i = 0; i < this.currentGameMatrixSize * this.currentGameMatrixSize; i++)
            {

                this.cardsMatched[i] = new int[2] { -1, -1 };
            }

            return true;
        }

        bool pushMatchedCardInMatchedMatrix(int row, int col)
        {

            for (int i = 0; i < this.currentGameMatrixSize * this.currentGameMatrixSize; i++)
            {

                if (this.cardsMatched[i][0] == -1 && this.cardsMatched[i][1] == -1)
                {

                    this.cardsMatched[i][0] = row;
                    this.cardsMatched[i][1] = col;

                    return true;
                }
            }

            return false;
        }

        bool setFirstCardSelected(int row, int col)
        {
            // VERIFY CARD POSITION
            this.currentSelectedCards[0] = new int[2];

            this.currentSelectedCards[0][0] = row;
            this.currentSelectedCards[0][1] = col;

            return true;
        }

        void setSecondCardSelected(int row, int col)
        {
            // VERIFY CARD POSITION
            this.currentSelectedCards[1] = new int[2];

            this.currentSelectedCards[1][0] = row;
            this.currentSelectedCards[1][1] = col;
        }

        bool verifyMatchedCard(int row, int col)
        {
            for (int i = 0; i < this.currentGameMatrixSize * this.currentGameMatrixSize; i++)
            {

                if (this.cardsMatched[i][0] == row && this.cardsMatched[i][1] == col)
                    return true;
            }

            return false;
        }

        bool createCardMatrix()
        {

            Random randomObj = new Random();
            
            bool[,] freeSpaces = new bool[this.currentGameMatrixSize, this.currentGameMatrixSize];
            Card[,] cardDeck = new Card[this.currentGameMatrixSize, this.currentGameMatrixSize];

            // SET INITIAL VALUES IN FREE SPACES MATRIX
            for (int i = 0; i < this.currentGameMatrixSize; i ++)
            {

                for (int j = 0; j < this.currentGameMatrixSize; j++)
                {

                    freeSpaces[i, j] = true;
                }
            }


            for (int i = 0; i < (this.currentGameMatrixSize * this.currentGameMatrixSize) / 2; i++)
            {

                Thread.Sleep(500);

                int cardNumber = Card.generateRandomNumber();
                char cardSuit = Card.generateRandomSuit();
                string cardColor = Card.getSuitColor(cardSuit);

                Card newCard = new Card(cardNumber, cardColor, cardSuit);

                // SET FIRST CARD
                int[] positionOfFirstCard = { randomObj.Next(0, this.currentGameMatrixSize), randomObj.Next(0, this.currentGameMatrixSize - 1) };

                while (!freeSpaces[ positionOfFirstCard[0], positionOfFirstCard[1] ]) {
                    positionOfFirstCard[0] = randomObj.Next(0, this.currentGameMatrixSize);
                    positionOfFirstCard[1] = randomObj.Next(0, this.currentGameMatrixSize);
                }

                cardDeck[positionOfFirstCard[0], positionOfFirstCard[1]] = newCard;
                freeSpaces[positionOfFirstCard[0], positionOfFirstCard[1]] = false;

                // SET SECOND CARD
                int[] positionOfSecondCard = { randomObj.Next(0, this.currentGameMatrixSize), randomObj.Next(0, this.currentGameMatrixSize - 1) };

                while (!freeSpaces[positionOfSecondCard[0], positionOfSecondCard[1]])
                {
                    positionOfSecondCard[0] = randomObj.Next(0, this.currentGameMatrixSize);
                    positionOfSecondCard[1] = randomObj.Next(0, this.currentGameMatrixSize);
                }

                cardDeck[positionOfSecondCard[0], positionOfSecondCard[1]] = newCard;
                freeSpaces[positionOfSecondCard[0], positionOfSecondCard[1]] = false;
            }

            this.cardsMatrix = cardDeck;

            return true;
        }

        public void play()
        {
            Console.Clear();

            this.userLogged = this.tryLogin();

            Console.WriteLine("Creating cards...");
            this.matrixCreated = createCardMatrix();

            Console.WriteLine("Creating matched cards matrix...");
            this.matchedCardsMatrixCreated = createMatchedCardsArray();

            if (this.userLogged && this.matrixCreated && this.matchedCardsMatrixCreated)
            {

                Console.Clear();

                while (!gameFinished)
                {

                    Console.Clear();


                    if (this.currentGameState != 3 && this.currentGameState != 4) { 

                        renderGameBanner();
                        renderGameInfos();
                        renderCards();
                    }

                    if (currentGameState == 0)
                    {

                        string cardMatrixIndexes;

                        GameLog.log("Selecione uma carta: ");
                        cardMatrixIndexes = Console.ReadLine();

                        if (!verifyCardIndexPosition(cardMatrixIndexes))
                            continue;


                        int cardRowPos = int.Parse(cardMatrixIndexes.Split(',')[0]);
                        int cardColPos = int.Parse(cardMatrixIndexes.Split(',')[1]);


                        // IF IS MATCHED CARD IT'S NOT POSSIBLE TO CHECK
                        bool isMatchedCard = verifyMatchedCard(cardRowPos, cardColPos);
                        if (isMatchedCard) continue;

                        bool inserted = setFirstCardSelected(cardRowPos, cardColPos);

                        Console.Beep();
                        currentGameState++;
                        continue;
                    } 

                    if (currentGameState == 1)
                    {

                        string cardMatrixIndexes;

                        GameLog.log("Selecione outra carta: ");
                        cardMatrixIndexes = Console.ReadLine();

                        if (!verifyCardIndexPosition(cardMatrixIndexes))
                            continue;

                        int cardRowPos = int.Parse(cardMatrixIndexes.Split(',')[0]);
                        int cardColPos = int.Parse(cardMatrixIndexes.Split(',')[1]);

                        // IF IS MATCHED CARD IT'S NOT POSSIBLE TO CHECK
                        bool isMatchedCard = verifyMatchedCard(cardRowPos, cardColPos);
                        if (isMatchedCard) continue;

                        setSecondCardSelected(cardRowPos, cardColPos);

                        Console.Beep();
                        currentGameState++;
                        continue;
                    }

                    if (currentGameState == 2)
                    {

                        this.numberOfSteps++;


                        this.currentGameScore = this.currentGameScore - (this.numberOfSteps * this.currentGameDecreaseMultiplier);

                        if (this.currentGameScore < 0)
                        {
                            this.currentGameState = 4;
                            continue;
                        }

                        Card firstCard = this.cardsMatrix[ this.currentSelectedCards[0][0], this.currentSelectedCards[0][1] ];
                        Card secondCard = this.cardsMatrix[ this.currentSelectedCards[1][0], this.currentSelectedCards[1][1] ];

                        bool isSameCard = firstCard.getCardNumber() == secondCard.getCardNumber() && firstCard.getCardSuit() == secondCard.getCardSuit();

                        if (isSameCard)
                        {

                            pushMatchedCardInMatchedMatrix(this.currentSelectedCards[0][0], this.currentSelectedCards[0][1]);
                            pushMatchedCardInMatchedMatrix(this.currentSelectedCards[1][0], this.currentSelectedCards[1][1]);
                        }
                        Console.WriteLine();

                        GameLog.log("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();

                        // FINISH GAME
                        if (this.cardsMatched[(this.currentGameMatrixSize * this.currentGameMatrixSize) - 2][0] != -1)
                        {
                            currentGameState++;
                            continue;
                        }

                        // RESET CURRENT SELECTED CARDS
                        clearCurrentSelectedCards();

                        // BACK TO SELECT FIRST CARD
                        currentGameState = 0;
                        continue;
                    }

                    if (this.currentGameState == 3)
                    {


                        GameLog.log("Parabéns! Você terminou o jogo com um total de: " + numberOfSteps.ToString() + " tentativas!");
                        GameLog.log("Seu score foi de: " + this.currentGameScore + " pontos \n\n");

                        this.plyController.addPlayerScore(this.currentPlayerName, this.currentGameScore);

                        GameLog.log("Pressione qualquer tecla para continuar...");

                        Console.ReadKey();
                        return;
                    }

                    if (this.currentGameState == 4)
                    {


                        GameLog.log("Seu score zerou e você perdeu, seu número de tentativas foi " + numberOfSteps.ToString() + " tentativas!");
                        GameLog.log("Pressione qualquer tecla para continuar...");

                        Console.ReadKey();
                        return;
                    }

                    Console.ReadKey();
                }
            }
        }
    }
}
