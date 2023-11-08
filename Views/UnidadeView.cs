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
                            Condominio = VincularCondominio(),
                            Morador = VincularMorador()
                        };

                        crudR.Create(unidadeR);
                    }
                    else
                    {
                        UnidadeComercial unidadeC = new UnidadeComercial()
                        {
                            Nome = RequisitarValor("Digite o nome da unidade"),
                            Condominio = VincularCondominio(),
                            Morador = VincularMorador()
                        };

                        crudC.Create(unidadeC);
                    }
                    break;
                case ACAO_VISUALIZAR:
                    IEnumerable<UnidadeResidencial> listaUnidadesR = crudR.Read();
                    IEnumerable<UnidadeComercial> listaUnidadesC = crudC.Read();

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
                        UnidadeResidencial unidadeAtualizacaoR = crudR.Read().ToList().Find(a => a.Id == idAtualizacao);

                        if (unidadeAtualizacaoR == null)
                        {
                            Console.WriteLine("Unidade não encontrada!");
                        }
                        else
                        {
                            unidadeAtualizacaoR.Nome = RequisitarValor("Digite o novo nome da unidade");
                            unidadeAtualizacaoR.Condominio = VincularCondominio();
                            unidadeAtualizacaoR.Morador = VincularMorador();

                            crudR.Update(unidadeAtualizacaoR);
                        }
                    }
                    else
                    {
                        UnidadeComercial unidadeAtualizacaoC = crudC.Read().ToList().Find(a => a.Id == idAtualizacao);

                        if (unidadeAtualizacaoC == null)
                        {
                            Console.WriteLine("Unidade não encontrada!");
                        }
                        else
                        {
                            unidadeAtualizacaoC.Nome = RequisitarValor("Digite o novo nome da unidade");
                            unidadeAtualizacaoC.Condominio = VincularCondominio();
                            unidadeAtualizacaoC.Morador = VincularMorador();

                            crudC.Update(unidadeAtualizacaoC);
                        }

                    }
                    break;
                case ACAO_EXCLUIR:
                    ExibirOpcoesTipoUnidade("excluída");
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
        
        private Condominio VincularCondominio()
        {
            CrudCondominio crudCondominio = new CrudCondominio();
            Condominio condominio = new Condominio();
            List<Condominio> moradoresCadastrados = crudCondominio.Read().ToList();

            if (moradoresCadastrados.Count > 0)
            {
                int idMorador = int.Parse(RequisitarValor("Insira o identificador do condomínio que a unidade pertence:"));

                condominio = Condominio.FindById(idMorador);
            }
            else
            {
                Console.WriteLine("Cadastre um condomínio e depois vincule-o à unidade!");
            }

            return condominio;
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
            Console.WriteLine($"Condomínio: {unidade.Condominio.NomeEmpresa}");
            Console.WriteLine($"Nome: {unidade.Nome}");
            Console.WriteLine($"Morador: {unidade.Morador.Nome}");
            Console.WriteLine("\n-----------------------------\n");
        }
    }
}