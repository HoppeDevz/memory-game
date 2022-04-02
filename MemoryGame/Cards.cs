using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class Cards
    {
        private int numero;
        private string cor, naipe;

        public Cards(int numero, string cor, string naipe)
        {
            this.numero = numero;
            this.cor = cor;
            this.naipe = naipe;
        }
    }
}
