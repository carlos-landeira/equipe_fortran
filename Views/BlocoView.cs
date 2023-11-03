using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho1.Models;
using Trabalho1.Services;
using Trabalho1.Views;

namespace equipe_fortran.Views
{
    public class BlocoView : View
    {
        public override void Main()
        {
            CrudBloco crud = new CrudBloco();
            
            ExibirOpcoesCrud("blocos");

            switch (ObterEscolhaUsuario())
            {
                case ACAO_CRIAR:
                    Bloco bloco = new Bloco
                    {
                        Nome = RequisitarValor("Digite o nome do bloco:")
                    };

                    crud.Create(bloco);
                    break;
                case ACAO_VISUALIZAR:
                    IEnumerable<Bloco> listaBlocos = crud.Read();

                    if (listaBlocos != null)
                    {
                        Console.WriteLine("Não há nenhum bloco cadastrado.");
                    }
                    else
                    {
                        foreach (var bl in listaBlocos)
                        {
                            ExibirBloco(bl);
                        }
                    }
                    break;
                case ACAO_EDITAR:
                    Console.Write("Digite o ID do bloco que deseja atualizar:");
                    int idAtualizacao = int.Parse(Console.ReadLine());

                    Bloco blocoAtualizacao = crud.Read().ToList().Find(a => a.Id == idAtualizacao);

                    crud.Update(blocoAtualizacao);
                    break;
                case ACAO_EXCLUIR:
                    Console.Write("Digite o ID do bloco que deseja excluir:");
                    int idExclusao = int.Parse(Console.ReadLine());

                    crud.Delete(idExclusao);
                    break;
                default:
                    Console.WriteLine("Esta opção não existe.");
                    break;
            }
        }
        private void ExibirBloco(Bloco bloco)
        {
            Console.WriteLine($"Id: {bloco.Id}");
            Console.WriteLine($"Nome: {bloco.Nome}");
            //Console.WriteLine($"Unidades: {bloco.Unidades}");
        }
    }
}