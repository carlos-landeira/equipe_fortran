namespace Trabalho1.Models;

public class Condominio: PessoaJuridica
{
    private static int ProximoId;

    public Condominio()
    {
        this.Id = ProximoId++;
    }
}