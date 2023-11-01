namespace Trabalho1.Models;

public class Morador: BaseModel
{
    private static int ProximoId;

    public Morador()
    {
        this.Id = ProximoId++;
    }
}