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
                        Administradora = VincularAdministradora()
                    };

                    crud.Create(condominio);
                    break;
                case ACAO_VISUALIZAR:
                    IEnumerable<Condominio> listaCondominios = crud.Read();

                    if (listaCondominios.Count() == 0)
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

                    condAtualizacao.NomeEmpresa = RequisitarValor("Digite o novo nome:");
                    condAtualizacao.Cnpj = RequisitarValor("Digite o novo CNPJ:");
                    condAtualizacao.Administradora = VincularAdministradora();

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

        private Administradora VincularAdministradora()
        {
            CrudAdministradora crudAdministradora = new CrudAdministradora();
            Administradora administradora = new Administradora();
            List<Administradora> administradorasCadastradas = crudAdministradora.Read().ToList();

            if (administradorasCadastradas.Count > 0)
            {
                int id = int.Parse(RequisitarValor("Digite o ID da administradora:"));

                administradora = administradorasCadastradas.Find(a => a.Id == id);
            }
            else
            {
                Console.WriteLine("Cadastre uma administradora para vincular!");
            }

            return administradora;
        }

        private void ExibirCondominio(Condominio condominio)
        {
            Console.WriteLine($"Id: {condominio.Id}");
            Console.WriteLine($"Administradora: {condominio.Administradora.NomeEmpresa}");
            Console.WriteLine($"Nome: {condominio.NomeEmpresa}");
            Console.WriteLine($"Documento: {condominio.Cnpj}");
        }
    }
}