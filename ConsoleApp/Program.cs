using Modelo;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            Agenda agenda = new Agenda();
            AgendaRepositorio agendaRepositorio = new AgendaRepositorio();

            const string caminhoArquivo = @"F:\agenda.txt";

            do
            {
                Console.WriteLine(); //Pular linha
                Console.WriteLine("-== Menu ==-");
                Console.WriteLine("1 - Adicionar Pessoa");
                Console.WriteLine("2 - Imprimir Pessoas");
                Console.WriteLine("3 - Buscar por Nome");
                Console.WriteLine("4 - Carregar agenda de arquivo");
                Console.WriteLine("5 - Gravar agenda em arquivo");
                Console.WriteLine("6 - Abrir o arquivo texto");
                Console.WriteLine("7 - Sair");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        AdicionarPessoa(agenda);
                        break;
                    case 2:
                        Console.Clear();
                        ImprimirPessoas(agenda);
                        break;
                    case 3:
                        Console.Clear();
                        BuscarPessoaPorNome(agenda);
                        break;
                    case 4:
                        Console.Clear();
                        agenda = agendaRepositorio.ObterAgendaDeArquivo(caminhoArquivo);
                        Console.WriteLine("Agenda carregada com sucesso!");
                        break;
                    case 5:
                        Console.Clear();
                        agendaRepositorio.GravarAgendaEmArquivo(agenda, caminhoArquivo);
                        Console.WriteLine("Agenda gravada com sucesso!");
                        break;
                    case 6:
                        Console.Clear();                        
                        System.Diagnostics.Process.Start(caminhoArquivo);
                        Console.WriteLine("Arquivo texto aberto!");
                        Console.WriteLine("IMPORTANTE: É apenas para você olha ele, lembre de fechar antes de gravar novamente!");
                        break;
                }

            } while (opcao != 7);
        }

        static void AdicionarPessoa(Agenda agenda)
        {
            Console.WriteLine("Digite o nome da pessoa:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o nascimento da pessoa (dd/mm/aaaa)");
            DateTime nascimento = DateTime.ParseExact(Console.ReadLine(), 
                "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //Crio o objeto pessoa
            Pessoa pessoa = new Pessoa();
            pessoa.Nome = nome;
            pessoa.Nascimento = nascimento;
            pessoa.Id = Guid.NewGuid();

            //Adiciona uma pessoa
            agenda.Adicionar(pessoa);

            Console.WriteLine("Pessoa adicionada com sucesso na agenda!");
        }

        public static void ImprimirPessoas(Agenda agenda)
        {
            List<Pessoa> pessoas = agenda.ObterTodasAsPessoas();

            Console.WriteLine("Lista de pessoas na agenda:");

            for (int i=0; i<pessoas.Count; i++)
            {
                Console.WriteLine("Id: " + pessoas[i].Id);
                Console.WriteLine("Nome: " + pessoas[i].Nome);
                Console.WriteLine("Nascimento: " + pessoas[i].Nascimento);
                Console.WriteLine();
            }
        }

        public static void BuscarPessoaPorNome(Agenda agenda)
        {
            //Perguntar o nome da pessoa
            Console.WriteLine("Digite o nome de quem procura:");
            string nome = Console.ReadLine();

            //Procuro a pessoa e imprimo
            Pessoa pessoa = agenda.BuscarPessoaPorNome(nome);

            if (pessoa == null)
            {
                Console.WriteLine("Pessoa não encontrada!");
                return;
            }

            Console.WriteLine("Pessoa encontrada:");
            Console.WriteLine(pessoa.Id);
            Console.WriteLine(pessoa.Nome);
            Console.WriteLine(pessoa.Nascimento);
        }
    }
}
