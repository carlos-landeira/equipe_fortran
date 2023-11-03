namespace Trabalho1.Models;

public class Administradora: PessoaJuridica
{
    public List<Condominio> Condominios { get; set; }
    
    private static int ProximoId;

    public Administradora()
    {
        this.Id = ProximoId++;
        this.Condominios = new List<Condominio>();
    }

    public static List<Condominio> ObterCondominiosPorId(int[] ids)
    {
        List<Condominio> condominios = new List<Condominio>();

        foreach (var id in ids)
        {
            condominios.Add(Condominio.FindById(id));
        }

        return condominios;
    }

    public string ToString()
    {
        string condominios = ";";

        foreach (var condominio in Condominios)
        { 
            condominios += $"{condominio.Nome}, ";
        }

        condominios.Substring(condominios.Length - 3);

        return base.ToString() + condominios;
    }
}