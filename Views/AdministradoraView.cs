using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho1.Models;
using Trabalho1.Services;
using Trabalho1.Views;

namespace equipe_fortran.Views
{
    public class AdministradoraView : View
    {
        public override void Main()
        {
            CrudAdministradora crud = new CrudAdministradora();

            ExibirOpcoesCrud("administradoras");

            switch (ObterEscolhaUsuario())
            {
                case ACAO_CRIAR:
                    Administradora administradora = new Administradora
                    {
                        Nome = RequisitarValor("Digite o nome da administradora:"),
                        Documento = RequisitarValor("Digite o documento:"),
                    };



                    crud.Create(administradora);
                    break;
                case ACAO_VISUALIZAR:
                    IEnumerable<Administradora> listaAdministradoras = crud.Read();

                    if (listaAdministradoras != null)
                    {
                        Console.WriteLine("Não há nenhuma administradora cadastrada.");
                    }
                    else
                    {
                        foreach (var adm in listaAdministradoras)
                        {
                            ExibirAdministradora(adm);
                        }
                    }
                    break;
                case ACAO_EDITAR:
                    Console.Write("Digite o ID da administradora que deseja atualizar: ");
                    int idAtualizacao = int.Parse(Console.ReadLine());

                    Administradora admAtualizacao = crud.Read().ToList().Find(a => a.Id == idAtualizacao);

                    crud.Update(admAtualizacao);
                    break;
                case ACAO_EXCLUIR:
                    Console.Write("Digite o ID da administradora que deseja excluir: ");
                    int idExclusao = int.Parse(Console.ReadLine());

                    crud.Delete(idExclusao);
                    break;
                default:
                    Console.WriteLine("Esta opção não existe.");
                    break;
            }
        }

        private List<Condominio> VincularCondominios()
        {
            CrudCondominio crudCondominio = new CrudCondominio();
            List<Condominio> condominios = new List<Condominio>();

            do
            {
                
            } while (true);
        }

        private void ExibirAdministradora(Administradora administradora)
        {
            Console.WriteLine($"Id: {administradora.Id}");
            Console.WriteLine($"Nome: {administradora.Nome}");
            Console.WriteLine($"Documento: {administradora.Documento}");
            Console.WriteLine($"Condomínios: {administradora.Condominios}");
        }
    }
}