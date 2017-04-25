using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoAndreXavier.Model;

namespace BancoAndreXavier.DAL
{
    class MovimentacaoDao
    {
        private static List<Movimentacao> movimentacoes = new List<Movimentacao>();

        public static bool AdicionarMovimentacao(Movimentacao movimentacao)
        {
            
            movimentacoes.Add(movimentacao);
            return true;
            
        }
        

        public static Movimentacao Depositar(Movimentacao movimentacao, Conta conta)
        {

            movimentacao.Tipo = "Deposito";
            movimentacao.Valor = movimentacao.ValorDeposito;
            conta.SaldoAtual = conta.SaldoAtual + movimentacao.ValorDeposito;
            return movimentacao;
        }

        public static Movimentacao Sacar(Movimentacao movimentacao, Conta conta)
        {
            if (movimentacao.ValorSaque < conta.SaldoAtual)
            {
                movimentacao.Tipo = "Saque";
                movimentacao.Valor = movimentacao.ValorSaque;
                conta.SaldoAtual = conta.SaldoAtual - movimentacao.ValorSaque;
                movimentacoes.Add(movimentacao);
                return movimentacao;
            }
            return null;
        }

        public static Movimentacao Sacar(Movimentacao movimentacao, Conta conta)
        {
            if (movimentacao.ValorSaque < conta.SaldoAtual)
            {
                movimentacao.Tipo = "Saque";
                movimentacao.Valor = movimentacao.ValorSaque;
                conta.SaldoAtual = conta.SaldoAtual - movimentacao.ValorSaque;

                return movimentacao;
            }
            return null;
        }
        public static List<Movimentacao> RetornarLista()
        {
            return movimentacoes;
        }
    }
}
