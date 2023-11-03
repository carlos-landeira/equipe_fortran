using Trabalho1.Models;

namespace Trabalho1.Services;

public class CrudBloco: ICrud<Bloco>
{
    public IEnumerable<Bloco> Read()
    {
        List<Bloco> lista = new List<Bloco>();
        string linha;
        
        try
        {
            StreamReader sr = new StreamReader("/home/carlos/Documents/Trabalho1/BancoDeDados/Bloco.txt");
            linha = sr.ReadLine();
            while (linha != null)
            {
                var bloco = linha.Split(';');
                Bloco model = new Bloco { Id = Convert.ToInt32(bloco[0]), Nome = bloco[1] };
                var idsUnidadesComerciais = bloco[2].Split(',');
                var idsUnidadesResidenciais = bloco[3].Split(',');

                model.UnidadesComerciais = ObterUnidadesComerciais(idsUnidadesComerciais);
                model.UnidadeResidenciais = ObterUnidadesResidenciais(idsUnidadesResidenciais);
                
                lista.Add(model);
                linha = sr.ReadLine();
            }
            sr.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        
        return lista;
    }

    public void Create(Bloco model)
    {
        throw new NotImplementedException();
    }

    public void Update(Bloco model)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    private List<UnidadeComercial> ObterUnidadesComerciais(string[] ids)
    {
        List<UnidadeComercial> unidades = new List<UnidadeComercial>();

        foreach (var id in ids)
        {
            unidades.Add(UnidadeComercial.FindById(int.Parse(id)));
        }

        return unidades;
    }
    
    private List<UnidadeResidencial> ObterUnidadesResidenciais(string[] ids)
    {
        
    }
}