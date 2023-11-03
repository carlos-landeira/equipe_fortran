using Trabalho1.Services;

namespace Trabalho1.Models;

public class Unidade: BaseModel
{
    public string Nome { get; set; }
    public Morador Morador { get; set; }

    public string ToString()
    {
        return base.ToString() + $";{Nome};{Morador.Id}";
    }
}