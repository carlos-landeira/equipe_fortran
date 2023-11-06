using Trabalho1.Services;

namespace Trabalho1.Models;

public class UnidadeComercial: Unidade
{
    private static int ProximoId;

    public UnidadeComercial()
    {
        this.Id = ProximoId++;
    }

    public static Unidade FindById(int id)
    {
        CrudUnidade<UnidadeComercial> crudUnidade = new CrudUnidade<UnidadeComercial>();
        List<Unidade> unidadesComerciais = crudUnidade.Read().ToList().Cast<Unidade>().ToList();

        return unidadesComerciais.Find(x => x.Id == id) ?? new UnidadeComercial();
    }
}