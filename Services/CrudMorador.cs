using System.Text.Json;
using Trabalho1.Models;

namespace Trabalho1.Services;

public class CrudMorador: ICrud<Morador>
{
    public IEnumerable<Morador> Read()
    {
        List<Morador> lista = new List<Morador>();
        string linha;
        
        try
        {
            StreamReader sr = new StreamReader("BancoDeDados/Morador.txt");
            linha = sr.ReadLine();
            while (linha != null)
            {
                Morador model = JsonSerializer.Deserialize<Morador>(linha);
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

    public void Create(Morador model)
    {
        try
        {
            StreamWriter sw = new StreamWriter("BancoDeDados/Morador.txt", true);
            sw.WriteLine(JsonSerializer.Serialize(model));
            sw.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }

    public void Update(Morador model)
    {
        List<Morador> lista = Read().ToList();
        Morador moradorParaAtualizar = lista.Find(x => x.Id == model.Id);

        if (moradorParaAtualizar != null)
        {
            moradorParaAtualizar.Nome = model.Nome;
            moradorParaAtualizar.DataNascimento = model.DataNascimento;
            
            StreamWriter sw = new StreamWriter("BancoDeDados/Morador.txt");
            foreach (var morador in lista)
            {
                sw.WriteLine(JsonSerializer.Serialize(morador));
            }
            
            sw.Close();
            AtualizarNaUnidade(model);
        }
        else
        {
            Console.WriteLine("Morador não encontrado");
        }
    }

    public void Delete(int id)
    {
        List<Morador> lista = Read().ToList();
        
        Morador moradorParaRemover = lista.Find(x => x.Id == id);

        if (moradorParaRemover != null)
        {
            DeletarNaUnidade(moradorParaRemover);
            lista.Remove(moradorParaRemover);
            StreamWriter sw = new StreamWriter("BancoDeDados/Morador.txt");
            foreach (var morador in lista)
            {
                sw.WriteLine(JsonSerializer.Serialize(morador));
            }
            
            sw.Close();
        }
        else
        {
            Console.WriteLine("Morador não encontrado");
        }
    }

    private void AtualizarNaUnidade(Morador model)
    {
        CrudUnidade<UnidadeComercial> crudUnidadeComercial = new CrudUnidade<UnidadeComercial>();
        List<UnidadeComercial> unidadesComerciais = crudUnidadeComercial.Read().ToList();

        CrudUnidade<UnidadeResidencial> crudUnidadeResidencial = new CrudUnidade<UnidadeResidencial>();
        List<UnidadeResidencial> unidadeResidenciais = crudUnidadeResidencial.Read().ToList();

        foreach (var unidadeComercial in unidadesComerciais)
        {
            if (unidadeComercial.Morador.Id == model.Id)
            {
                unidadeComercial.Morador.Nome = model.Nome;
                unidadeComercial.Morador.DataNascimento = model.DataNascimento;
                    
                crudUnidadeComercial.Update(unidadeComercial);
            }
        }
        
        foreach (var unidadeResidencial in unidadeResidenciais)
        {
            if (unidadeResidencial.Morador.Id == model.Id)
            {
                unidadeResidencial.Morador.Nome = model.Nome;
                unidadeResidencial.Morador.DataNascimento = model.DataNascimento;
                    
                crudUnidadeResidencial.Update(unidadeResidencial);
            }
        }
    }

    private void DeletarNaUnidade(Morador model)
    {
        CrudUnidade<UnidadeComercial> crudUnidadeComercial = new CrudUnidade<UnidadeComercial>();
        List<UnidadeComercial> unidadesComerciais = crudUnidadeComercial.Read().ToList();

        CrudUnidade<UnidadeResidencial> crudUnidadeResidencial = new CrudUnidade<UnidadeResidencial>();
        List<UnidadeResidencial> unidadeResidenciais = crudUnidadeResidencial.Read().ToList();

        foreach (var unidadeComercial in unidadesComerciais)
        {
            if (unidadeComercial.Morador.Id == model.Id)
            {
                unidadeComercial.Morador = null;

                crudUnidadeComercial.Update(unidadeComercial);
            }
        }
        
        foreach (var unidadeResidencial in unidadeResidenciais)
        {
            if (unidadeResidencial.Morador.Id == model.Id)
            {
                unidadeResidencial.Morador = null;

                crudUnidadeResidencial.Update(unidadeResidencial);
            }
        }
    }
}