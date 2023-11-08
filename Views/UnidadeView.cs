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
            CrudUnidade<UnidadeResidencial> crudR = new CrudUnidade<UnidadeResidencial>();
            CrudUnidade<UnidadeComercial> crudC = new CrudUnidade<UnidadeComercial>();

            switch (ObterEscolhaUsuario())
            {
                case ACAO_CRIAR:
                    ExibirOpcoesTipoUnidade("cadastrada");
                    string tipoUnidade = ObterEscolhaUsuario().ToUpper();

                    if (tipoUnidade == UNIDADE_TIPO_RESIDENCIAL)
                    {
                        UnidadeResidencial unidadeR = new UnidadeResidencial()
                        {
                            Nome = RequisitarValor("Digite o nome da unidade"),
                            Morador = VincularMorador()
                        };

                        crudR.Create(unidadeR);
                    }
                    else
                    {
                        UnidadeComercial unidadeC = new UnidadeComercial()
                        {
                            Nome = RequisitarValor("Digite o nome da unidade"),
                            Morador = VincularMorador()
                        };

                        crudC.Create(unidadeC);
                    }
                    break;
                case ACAO_VISUALIZAR:
                    IEnumerable<Unidade> listaUnidadesR = crudR.Read();
                    IEnumerable<Unidade> listaUnidadesC = crudC.Read();

                    if (listaUnidadesR.Count() == 0)
                    {
                        Console.WriteLine("Não há nenhuma unidade residencial cadastrada.");
                    }
                    else
                    {
                        Console.WriteLine("Unidades residenciais:\n");
                        foreach (var uniR in listaUnidadesR)
                        {
                            ExibirUnidade(uniR);
                        }
                    }

                    if (listaUnidadesC.Count() == 0)
                    {
                        Console.WriteLine("Não há nenhuma unidade comercial cadastrada.");
                    }
                    else
                    {
                        Console.WriteLine("Unidades comerciais:\n");
                        foreach (var uniC in listaUnidadesC)
                        {
                            ExibirUnidade(uniC);
                        }
                    }
                    break;
                case ACAO_EDITAR:
                    ExibirOpcoesTipoUnidade("editada");
                    string tipoUnidadeEdicao = ObterEscolhaUsuario().ToUpper();

                    Console.Write("Digite o ID da unidade que deseja atualizar:");
                    int idAtualizacao = int.Parse(Console.ReadLine());

                    if (tipoUnidadeEdicao == UNIDADE_TIPO_RESIDENCIAL)
                    {
                        Unidade unidadeAtualizacaoR = crudR.Read().ToList().Find(a => a.Id == idAtualizacao);

                        unidadeAtualizacaoR.Nome = RequisitarValor("Digite o novo nome da unidade");
                        unidadeAtualizacaoR.Morador = VincularMorador();

                        crudR.Update(unidadeAtualizacaoR);
                    }
                    else
                    {
                        Unidade unidadeAtualizacaoC = crudC.Read().ToList().Find(a => a.Id == idAtualizacao);

                        unidadeAtualizacaoC.Nome = RequisitarValor("Digite o novo nome da unidade");
                        unidadeAtualizacaoC.Morador = VincularMorador();

                        crudC.Update(unidadeAtualizacaoC);
                    }
                    break;
                case ACAO_EXCLUIR:
                    ExibirOpcoesTipoUnidade("escluída");
                    string tipoUnidadeExclusao = ObterEscolhaUsuario().ToUpper();

                    Console.Write("Digite o ID da unidade que deseja excluir:");
                    int idExclusao = int.Parse(Console.ReadLine());

                    if (tipoUnidadeExclusao == UNIDADE_TIPO_RESIDENCIAL)
                    {
                        crudR.Delete(idExclusao);
                    }
                    else
                    {
                        crudC.Delete(idExclusao);
                    }
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

        private void ExibirOpcoesTipoUnidade(string acao)
        {
            Console.WriteLine($"Qual o tipo da unidade a ser {acao}?");
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