using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho1.Models;
using Trabalho1.Services;
using Trabalho1.Views;

namespace equipe_fortran.Views
{
    public class MoradorView : View
    {
        public override void Main()
        {
            CrudMorador crud = new CrudMorador();

            ExibirOpcoesCrud("moradores");

            switch (ObterEscolhaUsuario())
            {
                case ACAO_CRIAR:
                    Morador morador = new Morador
                    {
                        Nome = RequisitarValor("Digite o nome do morador:"),
                        DataNascimento = RequisitarValor("Digite a data de nascimento:"),
                    };

                    crud.Create(morador);
                    break;
                case ACAO_VISUALIZAR:
                    IEnumerable<Morador> listaMoradores = crud.Read();

                    if (listaMoradores.Count() == 0)
                    {
                        Console.WriteLine("Não há nenhum morador cadastrado.");
                    }
                    else
                    {
                        foreach (var mor in listaMoradores)
                        {
                            ExibirMorador(mor);
                        }
                    }
                    break;
                case ACAO_EDITAR:
                    Console.Write("Digite o ID do morador que deseja atualizar:");
                    int idAtualizacao = int.Parse(Console.ReadLine());

                    Morador moradorAtualizacao = crud.Read().ToList().Find(a => a.Id == idAtualizacao);

                    moradorAtualizacao.Nome = RequisitarValor("Digite o novo nome:");
                    moradorAtualizacao.DataNascimento = RequisitarValor("Digite a nova data de nascimento:");

                    crud.Update(moradorAtualizacao);
                    break;
                case ACAO_EXCLUIR:
                    Console.Write("Digite o ID do morador que deseja excluir:");
                    int idExclusao = int.Parse(Console.ReadLine());

                    crud.Delete(idExclusao);
                    break;
                default:
                    Console.WriteLine("Esta opção não existe.");
                    break;
            }
        }

        private void ExibirMorador(Morador morador)
        {
            Console.WriteLine($"Id: {morador.Id}");
            Console.WriteLine($"Nome: {morador.Nome}");
            Console.WriteLine($"Data de Nascimento: {morador.DataNascimento}");
        }
    }
}