using equipe_fortran.Views;
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
    public const string ACAO_CRIAR = "1";
    public const string ACAO_VISUALIZAR = "2";
    public const string ACAO_EDITAR = "3";
    public const string ACAO_EXCLUIR = "4";

    public virtual void Main()
    {
        Console.WriteLine(GerarMensagemBoasVindas());

        do
        {
            ExibirOpcoesAcoes();

            switch (ObterEscolhaUsuario())
            {
                case OPCOES_ADMINISTRADORA:
                    AdministradoraView administradoraView = new();
                    administradoraView.Main();
                    break;
                case OPCOES_CONDOMINIO:
                    CondominioView condominioView = new();
                    condominioView.Main();
                    break;
                case OPCOES_BLOCOS:
                    BlocoView blocoView = new();
                    blocoView.Main();
                    break;
                case OPCOES_UNIDADES:
                    UnidadeView unidadeView = new();
                    unidadeView.Main();
                    break;
                case OPCOES_MORADORES:
                    MoradorView moradorView = new();
                    moradorView.Main();
                    break;
                default:
                    Console.WriteLine("Esta opção não existe.");
                    break;
            }
        } while (Continuar());
    }

    public string GerarMensagemBoasVindas()
    {
        DateTime dataAtual = DateTime.Now;
        string saudacao;

        if (dataAtual.Hour is >= 6 and <= 11)
        {
            saudacao = "Bom dia!";
        }
        else if (dataAtual.Hour is >= 12 and <= 17)
        {
            saudacao = "Boa tarde!";
        }
        else
        {
            saudacao = "Boa noite!";
        }

        return saudacao + " São " + dataAtual.ToString("HH:mm");
    }

    public bool Continuar()
    {
        Console.WriteLine($"Você deseja fazer uma nova operação? (s / n)");

        return ObterEscolhaUsuario()?.ToUpper() == "S";
    }

    public string? ObterEscolhaUsuario()
    {
        return Console.ReadLine()?.Trim();
    }

    public string RequisitarValor(string pergunta)
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

    public void ExibirOpcoesAcoes()
    {
        Console.WriteLine("Digite o que você deseja acessar:");
        Console.WriteLine($"{OPCOES_ADMINISTRADORA} - Administradoras");
        Console.WriteLine($"{OPCOES_CONDOMINIO} - Condominios");
        Console.WriteLine($"{OPCOES_BLOCOS} - Blocos");
        Console.WriteLine($"{OPCOES_UNIDADES} - Unidades");
        Console.WriteLine($"{OPCOES_MORADORES} - Moradores");
    }

    public void ExibirOpcoesCrud(string objeto)
    {
        Console.WriteLine($"Digite o que você deseja fazer com {objeto}:");
        Console.WriteLine($"{ACAO_CRIAR} - Criar");
        Console.WriteLine($"{ACAO_VISUALIZAR} - Visualizar");
        Console.WriteLine($"{ACAO_EDITAR} - Editar");
        Console.WriteLine($"{ACAO_EXCLUIR} - Excluir");
    }
}