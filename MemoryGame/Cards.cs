﻿using System;
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

        public Cards(int Numero, string Cor, string Naipe)
        {
            this.numero = Numero;
            this.cor = Cor;
            this.naipe = Naipe;
        }
    }
}
