using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoAndreXavier.Model;
using BancoAndreXavier.DAL;


namespace BancoAndreXavier.View
{
    class Program
    {
        static void Main(string[] args)
        {

            string opcao = null;
            Conta conta = new Conta();
            Movimentacao movimentacao = new Movimentacao();


            do
            {
                Console.Clear();
                Console.WriteLine("\n          ______________Folha de Pagamento_______________");
                Console.WriteLine("         |                                               |");
                Console.WriteLine("         |   1 - Cadastrar Conta                         |");
                Console.WriteLine("         |   2 - Depósito                                |");
                Console.WriteLine("         |   3 - Saque                                   |");
                Console.WriteLine("         |   4 - Extrato Bancário                        |");
                Console.WriteLine("         |   0 - Sair                                    |");
                Console.WriteLine("         |_______________________________________________|");
                Console.WriteLine("\nDigite a opção desejada: ");
                opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        conta = new Conta();
                        Console.Clear();
                        Console.WriteLine(" -- Cadastrar Conta -- \n");
                        Console.WriteLine("Digite o Número da Conta: ");
                        conta.NumeroConta = Console.ReadLine();
                        Console.WriteLine("Digite o nome do Cliente: ");
                        conta.NomeCliente = Console.ReadLine();
                        Console.WriteLine("Digite o saldo inicial da Conta: ");
                        conta.SaldoInicial = Convert.ToDouble(Console.ReadLine());
                        
                            if (ContaDao.AdicionarConta(conta) == true)
                            {
                            conta.DataAberturaConta = DateTime.Now;
                            conta.SaldoAtual = conta.SaldoInicial;
                            Console.WriteLine("Conta Cadastrada com Sucesso!");
                            }
                            else
                            {
                                
                                Console.WriteLine("Não foi possível adicionar a Conta!");
                            }
                        
                        break;
                    case "2":
                        conta = new Conta();
                        movimentacao = new Movimentacao();
                        Console.Clear();
                        Console.WriteLine(" -- Depositar -- \n");
                        Console.WriteLine("Digite o Número da Conta: ");
                        conta.NumeroConta = Console.ReadLine();
                        conta = ContaDao.BuscarContaPorNumero(conta);
                        if (conta != null)
                        {
                            
                            Console.WriteLine("Digite o valor do Deposito: ");
                            movimentacao.ValorDeposito = Convert.ToDouble(Console.ReadLine());
                            MovimentacaoDao.Depositar(movimentacao, conta);
                            movimentacao.DataMovimentacao = DateTime.Now;
                            MovimentacaoDao.AdicionarMovimentacao(movimentacao);
                            Console.WriteLine("Depósito Realizado com Sucesso: ");
                        }
                        else
                        {

                            Console.WriteLine("Conta não encontrada!");
                        }
                        break;
                    case "3":
                        conta = new Conta();
                        movimentacao = new Movimentacao();
                        Console.Clear();
                        Console.WriteLine(" -- Sacar -- \n");
                        Console.WriteLine("Digite o Número da Conta: ");
                        conta.NumeroConta = Console.ReadLine();
                        conta = ContaDao.BuscarContaPorNumero(conta);
                        if (conta != null)
                        {
                            
                            Console.WriteLine("Digite o valor do Saque: ");
                            movimentacao.ValorSaque = Convert.ToDouble(Console.ReadLine());

                            if (MovimentacaoDao.Sacar(movimentacao, conta) != null)
                            {
                                movimentacao.DataMovimentacao = DateTime.Now;
                                MovimentacaoDao.AdicionarMovimentacao(movimentacao);
                                Console.WriteLine("Saque Realizado com Sucesso: ");
                            }else { Console.WriteLine("Valor insuficiente"); }
                        }
                        else
                        {
                            Console.WriteLine("Conta não encontrada!");
                        }
                        break;
                    case "4":
                        conta = new Conta();
                        movimentacao = new Movimentacao();
                        Console.Clear();
                        Console.WriteLine(" -- Movimentações -- \n");
                        Console.WriteLine("Digite o Número da Conta: ");
                        conta.NumeroConta = Console.ReadLine();
                        conta = ContaDao.BuscarContaPorNumero(conta);
                        if (conta != null)
                        {
                            
                            Console.WriteLine(conta);
                            foreach (Movimentacao movimentacaoCadastrada in MovimentacaoDao.RetornarLista())
                            {

                                Console.WriteLine("\nTipo: " + movimentacao.Tipo + "Valor" + movimentacao.Valor + "Data: " + movimentacao.DataMovimentacao);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Conta não encontrada!");
                        }
                        break;
                    case "5":
                        
                        Console.Clear();
                        Console.WriteLine(" -- Listar Contas -- \n");
                        foreach (Conta contaCadastrada in ContaDao.RetornarLista())
                        {
                            Console.WriteLine("Conta: " + contaCadastrada);
                        }
                        break;
                    
                }
                Console.WriteLine("Aperte uma tecla para continuar");
                Console.ReadKey();
            } while (!opcao.Equals("0"));

        }
        }
            }
