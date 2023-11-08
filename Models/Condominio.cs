using Trabalho1.Services;

namespace Trabalho1.Models;

public class Condominio: PessoaJuridica
{
    // public List<Unidade> Unidades { get; set; }
    
    public Administradora Administradora { get; set; }
    
    private static int ProximoId;

    public Condominio()
    {
        this.Id = ProximoId++;
        // this.Unidades = new List<Unidade>();
    }

    public static Condominio FindById(int id)
    {
        CrudCondominio crudCondominio = new CrudCondominio();
        List<Condominio> condominios = crudCondominio.Read().ToList();
    
        return condominios.Find(x => x.Id == id) ?? new Condominio();
    }
}