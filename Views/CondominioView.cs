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
                        Cnpj = RequisitarValor("Digite o documento:"),
                        Unidades = VincularUnidades()
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

        private List<Unidade> VincularUnidades()
        {
            CrudUnidade crudUnidade = new CrudUnidade();
            List<Unidade> unidades = new List<Unidade>();
            List<Unidade> unidadesCadastradas = crudUnidade.Read().ToList();

            if (unidadesCadastradas.Count > 0)
            {
                int[] idsUnidades = Array.ConvertAll(RequisitarValor("Digite os identificadores das unidades separados por ',': ").Split(','), int.Parse);

                foreach (var id in idsUnidades)
                {
                    unidades.Add(Unidade.FindById(id));
                }
            }
            else
            {
                Console.WriteLine("Cadastre uma unidade e depois vincule-a ao condomínio!");
            }

            return unidades;
        }

        private void ExibirCondominio(Condominio condominio)
        {
            Console.WriteLine($"Id: {condominio.Id}");
            Console.WriteLine($"Nome: {condominio.NomeEmpresa}");
            Console.WriteLine($"Documento: {condominio.Cnpj}");

            List<Unidade> unidades = condominio.Unidades.ToList();

            foreach (var unidade in unidades)
            {
                Console.WriteLine($"Unidade {unidade.Id}: {unidade.Nome}");    
            }
        }
    }
}