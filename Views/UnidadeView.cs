using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho1.Models;
using Trabalho1.Services;
using Trabalho1.Views;

namespace equipe_fortran.Views
{
    public class UnidadeView : View
    {
        const string UNIDADE_TIPO_COMERCIAL = "C";
        const string UNIDADE_TIPO_RESIDENCIAL = "R";

        public override void Main()
        {
            ExibirOpcoesCrud("unidades");
            // instanciar crud aqui

            switch (ObterEscolhaUsuario())
            {
                case ACAO_CRIAR:
                    ExibirOpcoesTipoUnidade();
                    string tipoUnidade = ObterEscolhaUsuario().ToUpper();

                    if (tipoUnidade == UNIDADE_TIPO_RESIDENCIAL)
                    {
                        CrudUnidade<UnidadeResidencial> crudR = new CrudUnidade<UnidadeResidencial>();
                        UnidadeResidencial unidadeR = new UnidadeResidencial()
                        {
                            Nome = RequisitarValor("Digite o nome da unidade"),
                            Morador = VincularMorador()
                        };

                        crudR.Create(unidadeR);
                    }
                    else
                    {
                        CrudUnidade<UnidadeComercial> crudC = new CrudUnidade<UnidadeComercial>();
                        UnidadeComercial unidadeC = new UnidadeComercial()
                        {
                            Nome = RequisitarValor("Digite o nome da unidade"),
                            Morador = VincularMorador()
                        };

                        crudC.Create(unidadeC);
                    }
                    break;
                case ACAO_VISUALIZAR:
                    //IEnumerable<Unidade> listaUnidades = crud.Read();

                    // if (listaUnidades != null)
                    // {
                    //     Console.WriteLine("Não há nenhuma unidade cadastrado.");
                    // }
                    // else
                    // {
                    //     foreach (var uni in listaUnidades)
                    //     {
                    //         ExibirUnidade(uni);
                    //     }
                    // }
                    break;
                case ACAO_EDITAR:
                    Console.Write("Digite o ID da unidade que deseja atualizar:");
                    int idAtualizacao = int.Parse(Console.ReadLine());

                    // Unidade unidadeAtualizacao = crud.Read().ToList().Find(a => a.Id == idAtualizacao);

                    // crud.Update(unidadeAtualizacao);
                    break;
                case ACAO_EXCLUIR:
                    Console.Write("Digite o ID da unidade que deseja excluir:");
                    int idExclusao = int.Parse(Console.ReadLine());

                    // crud.Delete(idExclusao);
                    break;
                default:
                    Console.WriteLine("Esta opção não existe.");
                    break;
            }
        }

        private Morador VincularMorador()
        {
            CrudMorador crudMorador = new CrudMorador();
            Morador morador = new Morador();
            List<Morador> moradoresCadastrados = crudMorador.Read().ToList();

            if (moradoresCadastrados.Count > 0)
            {
                int idMorador = int.Parse(RequisitarValor("Insira o identificador do morador da unidade:"));

                morador = Morador.FindById(idMorador);
            }
            else
            {
                Console.WriteLine("Cadastre um morador e depois vincule-o à unidade!");
            }

            return morador;
        }

        private void ExibirOpcoesTipoUnidade()
        {
            Console.WriteLine("Qual o tipo da unidade a ser cadastrada?");
            Console.WriteLine("c - Comercial");
            Console.WriteLine("r - Residencial");
        }

        private void ExibirUnidade(Unidade unidade)
        {
            Console.WriteLine($"Id: {unidade.Id}");
            Console.WriteLine($"Nome: {unidade.Nome}");
            Console.WriteLine($"Morador: {unidade.Morador.Nome}");
        }
    }
}