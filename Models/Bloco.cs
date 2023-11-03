namespace Trabalho1.Models;

public class Bloco: BaseModel
{
    public string Nome { get; set; }
    public List<UnidadeComercial> UnidadesComerciais { get; set; }
    public List<UnidadeResidencial> UnidadeResidenciais { get; set; }
    
    private static int ProximoId;

    public Bloco()
    {
        this.Id = ProximoId++;
    }
}