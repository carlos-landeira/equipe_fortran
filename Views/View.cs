using Trabalho1.Models;
using Trabalho1.Services;

namespace Trabalho1.Views;

public class View
{
    const string OPCOES_ADMINISTRADORA = "1";
    const string OPCOES_CONDOMINIO = "2";
    const string OPCOES_BLOCOS = "3";
    const string OPCOES_UNIDADES = "4";
    const string OPCOES_MORADORES = "5";
    const string ACAO_CRIAR = "1";
    const string ACAO_VISUALIZAR = "2";
    const string ACAO_EDITAR = "3";
    const string ACAO_EXCLUIR = "4";

    public void Main()
    {
        Console.WriteLine(GerarMensagemBoasVindas());

        do
        {
            ExibirOpcoesAcoes();

            switch (ObterEscolhaUsuario())
            {
                case OPCOES_ADMINISTRADORA:
                    ManipularCrudAdministradora();
                    break;
                case OPCOES_CONDOMINIO:
                    ManipularCrudCondominio();
                    break;
                case OPCOES_BLOCOS:
                    ManipularCrudBloco();
                    break;
                case OPCOES_UNIDADES:
                    ManipularCrudUnidade();
                    break;
                case OPCOES_MORADORES:
                    ManipularCrudMorador();
                    break;
                default:
                    Console.WriteLine("Esta opção não existe.");
                    break;
            }
        } while (Continuar());
    }

    private string GerarMensagemBoasVindas()
    {
        DateTime dataAtual = DateTime.Now;
        string saudacao;

        if (dataAtual.Hour >= 6 && dataAtual.Hour <= 11)
        {
            saudacao = "Bom dia!";
        }
        else if (dataAtual.Hour >= 12 && dataAtual.Hour <= 17)
        {
            saudacao = "Boa tarde!";
        }
        else
        {
            saudacao = "Boa noite!";
        }

        return saudacao + " São " + dataAtual.ToString("HH:mm");
    }

    private bool Continuar()
    {
        Console.WriteLine($"Você deseja fazer uma nova operação? (s / n)");

        return ObterEscolhaUsuario()?.ToUpper() == "S";
    }

    private string? ObterEscolhaUsuario()
    {
        return Console.ReadLine()?.Trim();
    }

    private string RequisitarValor(string pergunta)
    {
        string? resposta;

        do
        {
            Console.WriteLine(pergunta);
            resposta = ObterEscolhaUsuario();
        }
        while (resposta == null);

        return resposta;
    }

    private void ExibirOpcoesAcoes()
    {
        Console.WriteLine("Digite o que você deseja acessar:");
        Console.WriteLine($"{OPCOES_ADMINISTRADORA} - Administradoras");
        Console.WriteLine($"{OPCOES_CONDOMINIO} - Condominios");
        Console.WriteLine($"{OPCOES_BLOCOS} - Blocos");
        Console.WriteLine($"{OPCOES_UNIDADES} - Unidades");
        Console.WriteLine($"{OPCOES_MORADORES} - Moradores");
    }

    private void ExibirOpcoesCrud(string objeto)
    {
        Console.WriteLine($"Digite o que você deseja fazer com {objeto}:");
        Console.WriteLine($"{ACAO_CRIAR} - Criar");
        Console.WriteLine($"{ACAO_VISUALIZAR} - Visualizar");
        Console.WriteLine($"{ACAO_EDITAR} - Editar");
        Console.WriteLine($"{ACAO_EXCLUIR} - Excluir");
    }

    private void ManipularCrudAdministradora()
    {
        ExibirOpcoesCrud("administradoras");
        CrudAdministradora crud = new CrudAdministradora();

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

    private void ManipularCrudCondominio()
    {
        ExibirOpcoesCrud("condomínios");
        //crud

        switch (ObterEscolhaUsuario())
        {
            case ACAO_CRIAR:
                Condominio condominio = new Condominio
                {
                    Nome = RequisitarValor("Digite o nome do condomínio:"),
                    Documento = RequisitarValor("Digite o documento:")
                };

                //crud.Create(condominio);
                break;
            case ACAO_VISUALIZAR:
                //IEnumerable<Condominio> listaCondominios = crud.Read();

                // if (listaCondominios != null)
                // {
                //     Console.WriteLine("Não há nenhum condomínio cadastrado.");
                // }
                // else
                // {
                //     foreach (var cond in listaCondominios)
                //     {
                //         ExibirCondominio(cond);
                //     }
                // }
                break;
            case ACAO_EDITAR:
                Console.Write("Digite o ID do condomínio que deseja atualizar:");
                int idAtualizacao = int.Parse(Console.ReadLine());

                // Condominio condAtualizacao = crud.Read().ToList().Find(a => a.Id == idAtualizacao);

                // crud.Update(condAtualizacao);
                break;
            case ACAO_EXCLUIR:
                Console.Write("Digite o ID do condomínio que deseja excluir:");
                int idExclusao = int.Parse(Console.ReadLine());

                // crud.Delete(idExclusao);
                break;
            default:
                Console.WriteLine("Esta opção não existe.");
                break;
        }
    }

    private void ManipularCrudBloco()
    {
        ExibirOpcoesCrud("blocos");
        // instanciar crud aqui

        switch (ObterEscolhaUsuario())
        {
            case ACAO_CRIAR:
                Bloco bloco = new Bloco
                {
                    //Nome = RequisitarValor("Digite o nome do bloco:")
                };

                //crud.Create(bloco);
                break;
            case ACAO_VISUALIZAR:
                //IEnumerable<Bloco> listaBlocos = crud.Read();

                // if (listaBlocos != null)
                // {
                //     Console.WriteLine("Não há nenhum bloco cadastrado.");
                // }
                // else
                // {
                //     foreach (var bl in listaBlocos)
                //     {
                //         ExibirBloco(bl);
                //     }
                // }
                break;
            case ACAO_EDITAR:
                Console.Write("Digite o ID do bloco que deseja atualizar:");
                int idAtualizacao = int.Parse(Console.ReadLine());

                // Bloco blocoAtualizacao = crud.Read().ToList().Find(a => a.Id == idAtualizacao);

                // crud.Update(blocoAtualizacao);
                break;
            case ACAO_EXCLUIR:
                Console.Write("Digite o ID do bloco que deseja excluir:");
                int idExclusao = int.Parse(Console.ReadLine());

                // crud.Delete(idExclusao);
                break;
            default:
                Console.WriteLine("Esta opção não existe.");
                break;
        }

    }

    private void ManipularCrudUnidade()
    {
        ExibirOpcoesCrud("unidades");
        // instanciar crud aqui

        switch (ObterEscolhaUsuario())
        {
            case ACAO_CRIAR:
                Unidade unidade = new Unidade
                {
                    //Nome = RequisitarValor("Digite o nome da unidade:")
                };

                //crud.Create(unidade);
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

    private void ManipularCrudMorador()
    {
        ExibirOpcoesCrud("moradores");
        // instanciar crud aqui

        switch (ObterEscolhaUsuario())
        {
            case ACAO_CRIAR:
                Morador morador = new Morador
                {
                    //Nome = RequisitarValor("Digite o nome do morador:")
                };

                //crud.Create(morador);
                break;
            case ACAO_VISUALIZAR:
                //IEnumerable<Morador> listaMoradores = crud.Read();

                // if (listaMoradores != null)
                // {
                //     Console.WriteLine("Não há nenhum morador cadastrado.");
                // }
                // else
                // {
                //     foreach (var mor in listaMoradores)
                //     {
                //         ExibirMorador(mor);
                //     }
                // }
                break;
            case ACAO_EDITAR:
                Console.Write("Digite o ID do morador que deseja atualizar:");
                int idAtualizacao = int.Parse(Console.ReadLine());

                // Morador moradorAtualizacao = crud.Read().ToList().Find(a => a.Id == idAtualizacao);

                // crud.Update(moradorAtualizacao);
                break;
            case ACAO_EXCLUIR:
                Console.Write("Digite o ID do morador que deseja excluir:");
                int idExclusao = int.Parse(Console.ReadLine());

                // crud.Delete(idExclusao);
                break;
            default:
                Console.WriteLine("Esta opção não existe.");
                break;
        }
    }

    private void ExibirAdministradora(Administradora administradora)
    {
        Console.WriteLine($"Id: {administradora.Id}");
        Console.WriteLine($"Nome: {administradora.Nome}");
        Console.WriteLine($"Documento: {administradora.Documento}");
        Console.WriteLine($"Condomínios: {administradora.Condominios}");
    }

    private void ExibirCondominio(Condominio condominio)
    {
        Console.WriteLine($"Id: {condominio.Id}");
        Console.WriteLine($"Nome: {condominio.Nome}");
        Console.WriteLine($"Documento: {condominio.Documento}");
        //Console.WriteLine($"Unidades: {condominio.Blocos}");
    }

    private void ExibirBloco(Bloco bloco)
    {
        Console.WriteLine($"Id: {bloco.Id}");
        Console.WriteLine($"Nome: {bloco.Nome}");
        //Console.WriteLine($"Unidades: {bloco.Unidades}");
    }

    private void ExibirUnidade(Unidade unidade)
    {
        Console.WriteLine($"Id: {unidade.Id}");
        Console.WriteLine($"Nome: {unidade.Nome}");
        //Console.WriteLine($"Moradores: {unidades.Moradores}");
    }

    private void ExibirMorador(Morador morador)
    {
        Console.WriteLine($"Id: {morador.Id}");
        //Console.WriteLine($"Nome: {morador.Nome}");
    }
}