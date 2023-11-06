using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho1.Models;
using Trabalho1.Services;
using Trabalho1.Views;

namespace equipe_fortran.Views
{
    public class CondominioView : View
    {


        public override void Main()
        {
            CrudCondominio crud = new CrudCondominio();
            
            ExibirOpcoesCrud("condomínios");

            switch (ObterEscolhaUsuario())
            {
                case ACAO_CRIAR:
                    Condominio condominio = new Condominio
                    {
                        NomeEmpresa = RequisitarValor("Digite o nome do condomínio:"),
                        Cnpj = RequisitarValor("Digite o documento:")
                    };

                    crud.Create(condominio);
                    break;
                case ACAO_VISUALIZAR:
                    IEnumerable<Condominio> listaCondominios = crud.Read();

                    if (listaCondominios != null)
                    {
                        Console.WriteLine("Não há nenhum condomínio cadastrado.");
                    }
                    else
                    {
                        foreach (var cond in listaCondominios)
                        {
                            ExibirCondominio(cond);
                        }
                    }
                    break;
                case ACAO_EDITAR:
                    Console.Write("Digite o ID do condomínio que deseja atualizar:");
                    int idAtualizacao = int.Parse(Console.ReadLine());

                    Condominio condAtualizacao = crud.Read().ToList().Find(a => a.Id == idAtualizacao);

                    crud.Update(condAtualizacao);
                    break;
                case ACAO_EXCLUIR:
                    Console.Write("Digite o ID do condomínio que deseja excluir:");
                    int idExclusao = int.Parse(Console.ReadLine());

                    crud.Delete(idExclusao);
                    break;
                default:
                    Console.WriteLine("Esta opção não existe.");
                    break;
            }
        }

        private void ExibirCondominio(Condominio condominio)
        {
            Console.WriteLine($"Id: {condominio.Id}");
            Console.WriteLine($"Nome: {condominio.NomeEmpresa}");
            Console.WriteLine($"Documento: {condominio.Cnpj}");
            Console.WriteLine($"Unidade: {condominio.Unidades}");
        }
    }
}