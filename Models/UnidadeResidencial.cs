using Trabalho1.Services;

namespace Trabalho1.Models;

public class UnidadeResidencial: Unidade
{
    private static int ProximoId;

    public UnidadeResidencial()
    {
        this.Id = ProximoId++;
    }

    public static Unidade FindById(int id)
    {
        CrudUnidade<UnidadeResidencial> crudUnidade = new CrudUnidade<UnidadeResidencial>();
        List<Unidade> unidadesResidenciais = crudUnidade.Read().ToList().Cast<Unidade>().ToList();

        return unidadesResidenciais.Find(x => x.Id == id) ?? new UnidadeResidencial();
    }
}