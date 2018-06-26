using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class AgendaRepositorio
    {
        public void GravarAgendaEmArquivo(Agenda agenda, string caminhoArquivo)
        {
            //Crio ou Substituo o arquivo
            var arquivo = new System.IO.StreamWriter(caminhoArquivo);

            //Obtenho a lista de pessoas da agenda
            List<Pessoa> pessoasDaAgenda = agenda.ObterTodasAsPessoas();

            //Escrevo no Arquivo
            for (int i=0; i<pessoasDaAgenda.Count; i++)
            {
                arquivo.WriteLine(pessoasDaAgenda[i].Id);
                arquivo.WriteLine(pessoasDaAgenda[i].Nome);
                arquivo.WriteLine(pessoasDaAgenda[i].Nascimento);
            }

            //Fecho o arquivo
            arquivo.Close();
        }

        public Agenda ObterAgendaDeArquivo(string caminhoArquivo)
        {
            //Agenda que será retornada
            Agenda agenda = new Agenda();

            //Le do arquivo e monta a agenda
            var arquivo = new System.IO.StreamReader(caminhoArquivo);
            while (!arquivo.EndOfStream) //Enquanto você não está no fim do arquivo
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Id = Guid.Parse(arquivo.ReadLine());
                pessoa.Nome = arquivo.ReadLine();
                pessoa.Nascimento = DateTime.Parse(arquivo.ReadLine());
                agenda.Adicionar(pessoa);
            }
            arquivo.Close();

            //Retorno a agenda
            return agenda;
        }
    }
}
