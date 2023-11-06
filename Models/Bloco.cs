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
        this.UnidadesComerciais = new List<UnidadeComercial>();
        this.UnidadeResidenciais = new List<UnidadeResidencial>();
    }

    public string ToString()
    {
        return base.ToString() +
               $"{Nome};{StringIdsUnidade(UnidadesComerciais.Cast<Unidade>().ToList())};{StringIdsUnidade(UnidadeResidenciais.Cast<Unidade>().ToList())}";
    }

    private string StringIdsUnidade(List<Unidade> unidades)
    {
        string resultado = "";

        foreach (var unidade in unidades)
        {
            resultado += $"{unidade.Id},";
        }

        if (resultado.Length > 1)
        {
            resultado = resultado.Remove(resultado.Length - 1, 1);
        }

        return resultado;
    }
}