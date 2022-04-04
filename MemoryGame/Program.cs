using System;
using System.Threading;

using MemGamePlayerController;
using MemoryGameLog;
using MemoryGameCore;
using MemoryGameMenu;
using MemoryGamePlay;

namespace MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
            void Beep(Int32 freq, Int32 duration)
            {

                Console.Beep(freq, duration);
            }

            void PlaySong()
            {
                Beep(1320, 500); Beep(990, 250); Beep(1056, 250); Beep(1188, 250); Beep(1320, 125); Beep(1188, 125); Beep(1056, 250); Beep(990, 250); Beep(880, 500); Beep(880, 250); Beep(1056, 250); Beep(1320, 500); Beep(1188, 250); Beep(1056, 250); Beep(990, 750); Beep(1056, 250); Beep(1188, 500); Beep(1320, 500); Beep(1056, 500); Beep(880, 500); Beep(880, 500); System.Threading.Thread.Sleep(250); Beep(1188, 500); Beep(1408, 250); Beep(1760, 500); Beep(1584, 250); Beep(1408, 250); Beep(1320, 750); Beep(1056, 250); Beep(1320, 500); Beep(1188, 250); Beep(1056, 250); Beep(990, 500); Beep(990, 250); Beep(1056, 250); Beep(1188, 500); Beep(1320, 500); Beep(1056, 500); Beep(880, 500); Beep(880, 500);

                if (repeatSound) ;
                System.Threading.Thread.Sleep(500);
                PlaySong();
            }

            Thread sondThread = new Thread(PlaySong) { IsBackground = true };
            sondThread.Start();
            */

            /*
             * Repo: https://github.com/HoppeDevz/memory-game
             * Authors: Gabriel Hoppe, Luigi, Giuliano

                ███╗   ███╗███████╗███╗   ███╗ ██████╗ ██████╗ ██╗   ██╗      ██████╗  █████╗ ███╗   ███╗███████╗
                ████╗ ████║██╔════╝████╗ ████║██╔═══██╗██╔══██╗╚██╗ ██╔╝     ██╔════╝ ██╔══██╗████╗ ████║██╔════╝
                ██╔████╔██║█████╗  ██╔████╔██║██║   ██║██████╔╝ ╚████╔╝█████╗██║  ███╗███████║██╔████╔██║█████╗  
                ██║╚██╔╝██║██╔══╝  ██║╚██╔╝██║██║   ██║██╔══██╗  ╚██╔╝ ╚════╝██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  
                ██║ ╚═╝ ██║███████╗██║ ╚═╝ ██║╚██████╔╝██║  ██║   ██║        ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗
                ╚═╝     ╚═╝╚══════╝╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═╝   ╚═╝         ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝
            */

            Core gameCore = new Core();
            PlayerController playerController = new PlayerController();

            // INITIALIZE GAME CORE //
            gameCore.initializeGameCore();

            bool menuActivated = true;

            playerController.addPlayerScore("gabrielh2c", 12.32);

            while (menuActivated)
            {

                void createPlayerOption()
                {
                    // CLEAR CONSOLE
                    Console.Clear();

                    // PAGE BANNER
                    Console.WriteLine();
                    Console.WriteLine("  ██████╗ ███████╗ ██████╗ ██╗███████╗████████╗███████╗██████╗ ");
                    Console.WriteLine("  ██╔══██╗██╔════╝██╔════╝ ██║██╔════╝╚══██╔══╝██╔════╝██╔══██╗");
                    Console.WriteLine("  ██████╔╝█████╗  ██║  ███╗██║███████╗   ██║   █████╗  ██████╔╝");
                    Console.WriteLine("  ██╔══██╗██╔══╝  ██║   ██║██║╚════██║   ██║   ██╔══╝  ██╔══██╗");
                    Console.WriteLine("  ██║  ██║███████╗╚██████╔╝██║███████║   ██║   ███████╗██║  ██║");
                    Console.WriteLine("  ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝ ");
                    Console.WriteLine();

                    string username;
                    string password;

                    GameLog.logColoredTextWithPrefix("[REGISTER-PLAYER] ", "Digite o username: ", 1, false);
                    username = Console.ReadLine();

                    GameLog.logColoredTextWithPrefix("[REGISTER-PLAYER] ", "Digite a senha: ", 1, false);
                    password = Console.ReadLine();

                    bool success = playerController.tryRegisterPlayer(username, password);

                    if (!success)
                    {
                        char option;

                        GameLog.logColoredTextWithPrefix("[WARNING] ", "Já existe um usuário com este username, deseja tentar novamente? y/N ", 3, false);
                        option = char.Parse(Console.ReadLine());

                        if (option == 'y') createPlayerOption();

                    }
                }

                void gameSettingsOption()
                {
                    // CLEAR CONSOLE
                    Console.Clear();

                    // PAGE BANNER
                    Console.WriteLine();
                    Console.WriteLine(" ███████╗███████╗████████╗████████╗██╗███╗   ██╗ ██████╗ ███████╗");
                    Console.WriteLine(" ██╔════╝██╔════╝╚══██╔══╝╚══██╔══╝██║████╗  ██║██╔════╝ ██╔════╝");
                    Console.WriteLine(" ███████╗█████╗     ██║      ██║   ██║██╔██╗ ██║██║  ███╗███████╗");
                    Console.WriteLine(" ╚════██║██╔══╝     ██║      ██║   ██║██║╚██╗██║██║   ██║╚════██║");
                    Console.WriteLine(" ███████║███████╗   ██║      ██║   ██║██║ ╚████║╚██████╔╝███████║");
                    Console.WriteLine(" ╚══════╝╚══════╝   ╚═╝      ╚═╝   ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝");
                    Console.WriteLine();

                    int matrixSize = MemoryGameUtils.GameUtils.getMatrixSize();
                    double decreaseMultiplier = MemoryGameUtils.GameUtils.getDecreaseMultiplier();

                    GameLog.logColoredTextWithPrefix("[SETTINGS] ", "Tamanho da matriz: " + matrixSize.ToString(), 1, true);
                    GameLog.logColoredTextWithPrefix("[SETTINGS] ", "% de perda ao errar: " + decreaseMultiplier.ToString(), 1, true);
                    Console.WriteLine();

                    GameLog.logColoredTextWithPrefix("[ 1 ] ", "Mudar tamanho da matriz", 1, true);
                    GameLog.logColoredTextWithPrefix("[ 2 ] ", "Mudar % de perda ao errar", 1, true);
                    GameLog.logColoredTextWithPrefix("[ 3 ] ", "Sair", 1, true);

                    Console.WriteLine();

                    int option = 0;
                    option = int.Parse(Console.ReadLine());

                    switch (option) {

                        case 1:
                        {

                            Console.WriteLine("Digite o novo valor: ");
                            int newVal = int.Parse(Console.ReadLine());

                            MemoryGameUtils.GameUtils.setMatrixSize(newVal);

                            gameSettingsOption();
                            break;
                        }

                        case 2:
                        {

                            Console.WriteLine("Digite o novo valor: ");
                            double newVal = double.Parse(Console.ReadLine());

                            MemoryGameUtils.GameUtils.setDecreaseMultiplier(newVal);

                            gameSettingsOption();
                            break;
                        }

                        case 3:
                        {
                            // CLOSE SETTINGS PAGE
                            break;
                        }

                        default: break;
                    }


                    Console.ReadKey();
                }

                void searchPlayerScore()
                {
                    // CLEAR CONSOLE
                    Console.Clear();

                    // PAGE BANNER
                    Console.WriteLine();
                    Console.WriteLine("  ███████╗ ██████╗ ██████╗ ██████╗ ███████╗");
                    Console.WriteLine("  ██╔════╝██╔════╝██╔═══██╗██╔══██╗██╔════╝");
                    Console.WriteLine("  ███████╗██║     ██║   ██║██████╔╝█████╗  ");
                    Console.WriteLine("  ╚════██║██║     ██║   ██║██╔══██╗██╔══╝  ");
                    Console.WriteLine("  ███████║╚██████╗╚██████╔╝██║  ██║███████╗");
                    Console.WriteLine("  ╚══════╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝");
                    Console.WriteLine();

                    string username;
                    string password;

                    GameLog.logColoredTextWithPrefix("[SEARCH-SCORE] ", "Digite o username: ", 1, false);
                    username = Console.ReadLine();

                    GameLog.logColoredTextWithPrefix("[SEARCH-SCORE] ", "Digite a senha: ", 1, false);
                    password = Console.ReadLine();

                    double playerScore = playerController.getPlayerScore(username, password);

                    switch(playerScore)
                    {
                        case -1:
                        {
                            GameLog.logColoredTextWithPrefix("[SCORE-SYSTEM] ", "Usuário não encontrado, deseja tentar novamente? y/N ", 3, false);

                            char option = char.Parse(Console.ReadLine());

                            if (option == 'y')
                            {

                                searchPlayerScore();
                                return;
                            }

                            break;
                        }

                        case -2:
                        {
                            GameLog.logColoredTextWithPrefix("[SCORE-SYSTEM] ", "Credenciais incorretas, deseja tentar novamente? y/N ", 3, false);

                            char option = char.Parse(Console.ReadLine());

                            if (option == 'y')
                            {

                                searchPlayerScore();
                                return;
                            }
                            break;
                        }

                        default:
                        {

                            GameLog.logColoredTextWithPrefix("[SCORE-SYSTEM] ", "Score do jogador: " + playerScore.ToString(), 1, true);
                            Console.WriteLine();
                            GameLog.logColoredTextWithPrefix("[SCORE-SYSTEM] ", "Pressione qualquer tecla para sair...", 1, true);
                            Console.ReadKey();
                            break;
                        }
                    }

                }

                // RENDER GAME MENU
                Int16 optionSelected = GameMenu.renderGameMenu();

                switch (optionSelected)
                {

                    case 1:
                    {

                        createPlayerOption();
                        break;
                    }

                    case 2:
                    {

                        gameSettingsOption();
                        break;
                    }

                    case 3:
                    {

                        MemGame newGame = new MemGame();

                        newGame.play();
                        break;
                    }

                    case 4:
                    {

                        searchPlayerScore();
                        break;
                    }

                    default:
                    {
                        menuActivated = false;
                        break;
                    }
                }

                Console.Clear();
            }
        }
    }
}
