namespace Trabalho1.Models;

public class PessoaJuridica: BaseModel
{
    public string Nome { get; set; }
    
    public string Documento { get; set; }

    public override string ToString()
    {
        return base.ToString() + $";{Nome};{Documento}";
    }
}