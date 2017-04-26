using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoAndreXavier.Model
{
    class Conta
    {
        public string NumeroConta { get; set; }
        public string NomeCliente { get; set; }
        public Double SaldoInicial { get; set; }
        public Double SaldoAtual { get; set; }
        
        public DateTime DataAberturaConta { get; set; }
        public Movimentacao MovimentacaoConta { get; set; }
        
        public override string ToString()
        {
            return "Numero da Conta: " + NumeroConta +"\nNome: " + NomeCliente  + "\nSaldo: " + SaldoAtual +"\nAbertura da Conta: "+ DataAberturaConta+"\n";
        }
    }
}
