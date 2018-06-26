using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Agenda
    {
        private List<Pessoa> agenda;

        public Agenda()
        {
            agenda = new List<Pessoa>();
        }

        public int ObterQuantidadePessoas()
        {
            return agenda.Count;
        }

        public void Adicionar(Pessoa pessoa)
        {
            agenda.Add(pessoa);
        }

        public void Atualizar(Pessoa pessoaComAlteracao)
        {
            //Deleto a Pessoa da lista
            for (int i=0; i<agenda.Count; i++)
            {
                if (agenda[i].Id == pessoaComAlteracao.Id)
                    agenda.RemoveAt(i);
            }

            //Adiciono novamente a pessoa
            agenda.Add(pessoaComAlteracao);

            //OPÇÃO BEM INTERESSANTE
            ////Obtenho referência a pessoa não alterada pelo ID
            //Pessoa pessoaOriginal = null;
            //for (int i = 0; i < agenda.Count; i++)
            //{
            //    if (agenda[i].Id == pessoaComAlteracao.Id)
            //        pessoaOriginal = agenda[i];
            //}
            ////Verifico se encontrei a pessoa na lista
            //if (pessoaOriginal == null)
            //    return;

            ////Remove a pessoa com as propriedade originais
            //agenda.Remove(pessoaOriginal);

            ////Adiciono de volta a pessoa com alterações
            //agenda.Add(pessoaComAlteracao);

            //NÃO RECOMENDO FAZER DESSE JEITO
            //Dessa forma, se você adicionar uma única propriedade
            //nova, você precisa lembrar de atualizar nessa função.
            //for (int i=0; i<agenda.Count; i++)
            //{
            //    if (agenda[i].Id == pessoa.Id)
            //    {
            //        agenda[i].Nome = pessoa.Nome;
            //        agenda[i].Nascimento = pessoa.Nascimento;
            //    }
            //}
        }

        public void Remover(Guid id)
        {
            for (int i=0; i<agenda.Count; i++)
            {
                if (agenda[i].Id == id)
                    agenda.RemoveAt(i);
            }
        }

        public List<Pessoa> ObterTodasAsPessoas()
        {
            return agenda;
        }

        public Pessoa BuscarPessoaPorNome(string nome)
        {
            for (int i=0; i<agenda.Count; i++)
            {
                //if (agenda[i].Nome.ToLower().Contains(nome.ToLower()))
                if (agenda[i].Nome.Contains(nome))
                    return agenda[i];
            }
            return null; //Não encontrou a pessoa em questão
        }

        public Pessoa BuscarPessoaPorDataNascimento(DateTime nascimento)
        {
            for (int i=0; i<agenda.Count; i++)
            {
                if (agenda[i].Nascimento == nascimento)
                    return agenda[i];
            }
            return null;
        }

        public List<Pessoa> BuscarPessoasPorNome(string nome)
        {
            List<Pessoa> pessoasComMesmoNome = new List<Pessoa>();
            for (int i = 0; i < agenda.Count; i++)
            {
                if (agenda[i].Nome.Contains(nome))
                    pessoasComMesmoNome.Add(agenda[i]);
            }
            return pessoasComMesmoNome; //Não encontrou a pessoa em questão
        }


    }
}

