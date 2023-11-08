using Trabalho1.Services;

namespace Trabalho1.Models;

public class Condominio: PessoaJuridica
{
    public Administradora Administradora { get; set; }
    
    private static int ProximoId;

    public Condominio()
    {
        this.Id = ProximoId++;
    }

    public static Condominio FindById(int id)
    {
        CrudCondominio crudCondominio = new CrudCondominio();
        List<Condominio> condominios = crudCondominio.Read().ToList();
    
        return condominios.Find(x => x.Id == id) ?? new Condominio();
    }
}