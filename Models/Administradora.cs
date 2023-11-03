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

    public override string ToString()
    {
        if (Condominios.Count != 0)
        {
            string condominios = ";";

            foreach (var condominio in Condominios)
            {
                condominios += $"{condominio.Nome}, ";
            }

            condominios.Substring(condominios.Length - 3);

            return base.ToString() + condominios;
        }

        return base.ToString();
    }
}