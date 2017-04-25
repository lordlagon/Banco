using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoAndreXavier.Model
{
    class Movimentacao
    {
        public string Tipo { get; set; }
        public double Valor { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public double ValorDeposito { get; set; }
        public double ValorSaque { get; set; }
               

        public override string ToString()
        {
            return "Tipo: " + Tipo + "  Valor: " +Valor.ToString("C2")+"    Data: "+ DataMovimentacao;
        }
    }
}
