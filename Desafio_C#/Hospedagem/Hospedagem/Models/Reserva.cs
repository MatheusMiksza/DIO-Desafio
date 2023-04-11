using System;
using System.Collections.Generic;
using System.Text;

namespace Hospedagem.Models
{
    class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite suite { get; set; }
        public decimal valor { get; set; }

        public int dias { get; set; }
        public Reserva()
        {
            Hospedes = new List<Pessoa>();
        }

    }
}
