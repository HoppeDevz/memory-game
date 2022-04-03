using System;

using MemoryGameLog;

namespace MemoryGameMenu
{
    public class GameMenu
    {

        public static void renderGameBanner()
        {
            Console.WriteLine();
            Console.WriteLine("  ███╗   ███╗███████╗███╗   ███╗ ██████╗ ██████╗ ██╗   ██╗      ██████╗  █████╗ ███╗   ███╗███████╗");
            Console.WriteLine("  ████╗ ████║██╔════╝████╗ ████║██╔═══██╗██╔══██╗╚██╗ ██╔╝     ██╔════╝ ██╔══██╗████╗ ████║██╔════╝");
            Console.WriteLine("  ██╔████╔██║█████╗  ██╔████╔██║██║   ██║██████╔╝ ╚████╔╝█████╗██║  ███╗███████║██╔████╔██║█████╗  ");
            Console.WriteLine("  ██║╚██╔╝██║██╔══╝  ██║╚██╔╝██║██║   ██║██╔══██╗  ╚██╔╝ ╚════╝██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  ");
            Console.WriteLine("  ██║ ╚═╝ ██║███████╗██║ ╚═╝ ██║╚██████╔╝██║  ██║   ██║        ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗");
            Console.WriteLine("  ╚═╝     ╚═╝╚══════╝╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═╝   ╚═╝         ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝");
            Console.WriteLine();
        }

        public static Int16 renderGameMenu()
        {

            Console.WriteLine();
            Console.WriteLine("  ███╗   ███╗███████╗███╗   ███╗ ██████╗ ██████╗ ██╗   ██╗      ██████╗  █████╗ ███╗   ███╗███████╗");
            Console.WriteLine("  ████╗ ████║██╔════╝████╗ ████║██╔═══██╗██╔══██╗╚██╗ ██╔╝     ██╔════╝ ██╔══██╗████╗ ████║██╔════╝");
            Console.WriteLine("  ██╔████╔██║█████╗  ██╔████╔██║██║   ██║██████╔╝ ╚████╔╝█████╗██║  ███╗███████║██╔████╔██║█████╗  ");
            Console.WriteLine("  ██║╚██╔╝██║██╔══╝  ██║╚██╔╝██║██║   ██║██╔══██╗  ╚██╔╝ ╚════╝██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  ");
            Console.WriteLine("  ██║ ╚═╝ ██║███████╗██║ ╚═╝ ██║╚██████╔╝██║  ██║   ██║        ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗");
            Console.WriteLine("  ╚═╝     ╚═╝╚══════╝╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═╝   ╚═╝         ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝");
            Console.WriteLine();

            GameLog.logColoredTextWithPrefix("[ 1 ] ", "Cadastrar Jogador", 1);
            GameLog.logColoredTextWithPrefix("[ 2 ] ", "Configurar Jogo", 1);
            GameLog.logColoredTextWithPrefix("[ 3 ] ", "Jogar", 1);
            GameLog.logColoredTextWithPrefix("[ 4 ] ", "Consultar pontuação", 1);

            Console.WriteLine();
            Console.WriteLine("Digite a opção desejada: ");

            return Int16.Parse(Console.ReadLine());
        }
    }
}
