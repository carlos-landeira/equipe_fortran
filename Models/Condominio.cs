using Trabalho1.Services;

namespace Trabalho1.Models;

public class Condominio: PessoaJuridica
{
    public List<Unidade> Unidades { get; set; }
    
    private static int ProximoId;

    public Condominio()
    {
        this.Id = ProximoId++;
        this.Unidades = new List<Unidade>();
    }

    public static Condominio FindById(int id)
    {
        CrudCondominio crudCondominio = new CrudCondominio();
        List<Condominio> condominios = crudCondominio.Read().ToList();

        return condominios.Find(x => x.Id == id) ?? new Condominio();
    }

    public string ToString()
    {
        if (Unidades.Count > 0)
        {
            string unidades = ";";

            foreach (var unidade in Unidades)
            { 
                unidades += $"{unidade.Id},";
            }

            unidades = unidades.Remove(unidades.Length - 1, 1); // Remover a última ','

            return base.ToString() + unidades;
        }

        return base.ToString();
    }
}