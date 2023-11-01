namespace Trabalho1.Models;

public class Administradora: PessoaJuridica
{
    public List<Condominio> Condominios { get; set; }
    
    private static int ProximoId;

    public Administradora()
    {
        this.Id = ProximoId++;
    }
}