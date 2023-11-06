namespace Trabalho1.Models;

public class PessoaJuridica: BaseModel
{
    public string NomeEmpresa { get; set; }
    
    public string Cnpj { get; set; }
    
    public List<Condominio> AdministradoraCondominios { get; set; }

    public string ToString()
    {
        return base.ToString() + $";{NomeEmpresa};{Cnpj}";
    }
}