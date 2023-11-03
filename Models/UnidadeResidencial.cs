using Trabalho1.Services;

namespace Trabalho1.Models;

public class UnidadeResidencial: Unidade
{
    private static int ProximoId;

    public UnidadeResidencial()
    {
        this.Id = ProximoId++;
    }

    public static UnidadeResidencial FindById(int id)
    {
        CrudUnidade<UnidadeResidencial> crudUnidade = new CrudUnidade<UnidadeResidencial>();
        List<UnidadeResidencial> unidadesResidenciais = crudUnidade.Read().ToList();
    
        return unidadesResidenciais.Find(x => x.Id == id) ?? new UnidadeResidencial();
    }
}