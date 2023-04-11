using System;
using System.Collections.Generic;
using System.Text;

namespace Hospedagem.Models
{
    class Suite
    { 
        public int Numero { get; set; }
        public string Tipo { get; set; }
        public int Capacidade { get; set; }
        public decimal Valor { get; set; }

        public bool Locado { get; set; }

    }
}
