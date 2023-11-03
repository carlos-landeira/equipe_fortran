using Trabalho1.Services;

namespace Trabalho1.Models;

public class Condominio: PessoaJuridica
{
    private static int ProximoId;

    public Condominio()
    {
        this.Id = ProximoId++;
    }

    public Condominio FindById(int id)
    {
        CrudCondominio crudCondominio = new CrudCondominio();
        List<Condominio> condominios = crudCondominio.Read().ToList();

        return condominios.Find(x => x.Id == id) ?? new Condominio();
    }
}