using Trabalho1.Services;

namespace Trabalho1.Models;

public class Condominio: PessoaJuridica
{
    public List<Bloco> Blocos { get; set; }
    private static int ProximoId;

    public Condominio()
    {
        this.Id = ProximoId++;
        this.Blocos = new List<Bloco>();
    }

    public static Condominio FindById(int id)
    {
        CrudCondominio crudCondominio = new CrudCondominio();
        List<Condominio> condominios = crudCondominio.Read().ToList();

        return condominios.Find(x => x.Id == id) ?? new Condominio();
    }

    public string ToString()
    {
        if (Blocos.Count > 0)
        {
            string blocos = ";";

            foreach (var bloco in Blocos)
            { 
                blocos += $"{bloco.Id},";
            }

            blocos = blocos.Remove(blocos.Length - 1, 1); // Remover a última ','

            return base.ToString() + blocos;
        }

        return base.ToString();
    }
}