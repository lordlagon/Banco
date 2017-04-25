using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoAndreXavier.Model;

namespace BancoAndreXavier.DAL
{
    class ContaDao
    {

        private static List<Conta> contas = new List<Conta>();

        public static bool AdicionarConta(Conta conta)
        {
            if (BuscarContaPorNumero(conta) != null)
            {
                return false;
            }
            contas.Add(conta);
            return true;
        }

        public static Conta BuscarContaPorNumero(Conta conta)
        {
            foreach (Conta contaCadastrada in contas)
            {
                if (conta.NumeroConta.Equals(contaCadastrada.NumeroConta))
                {
                    return contaCadastrada;
                }
            }
            return null;
        }

        public static List<Conta> RetornarLista()
        {
            return contas;
        }
    }
}
