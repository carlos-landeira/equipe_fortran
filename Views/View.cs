using Trabalho1.Models;
using Trabalho1.Services;

namespace Trabalho1.Views;

public class View
{
    public void Main()
    {
        CrudAdministradora c = new CrudAdministradora();
        c.Create(new Administradora());
    }

    private string GerarMensagemBoasVindas()
    {
        DateTime dataAtual = DateTime.Now;
        string saudacao;

        if (dataAtual.Hour >= 6 && dataAtual.Hour <= 11)
        {
            saudacao = "Bom dia!";
        } else if (dataAtual.Hour >= 12 && dataAtual.Hour <= 17)
        {
            saudacao = "Boa tarde!";
        } else
        {
            saudacao = "Boa noite!";
        }

        return saudacao + " São " + dataAtual.ToString("HH:mm");
    }
}