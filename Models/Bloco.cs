namespace Trabalho1.Models;

public class Bloco: BaseModel
{
    private string Nome { get; set; }
    private List<Unidade> Unidades { get; set; }
    
    private static int ProximoId;

    public Bloco()
    {
        this.Id = ProximoId++;
    }
}