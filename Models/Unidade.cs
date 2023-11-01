namespace Trabalho1.Models;

public class Unidade: BaseModel
{
    private string Nome { get; set; }
    private Morador Morador { get; set; }
    
    private static int ProximoId;

    public Unidade()
    {
        this.Id = ProximoId++;
    }
}