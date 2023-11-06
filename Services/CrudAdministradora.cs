using System.Text.Json;
using Trabalho1.Models;

namespace Trabalho1.Services;

public class CrudAdministradora: ICrud<Administradora>
{
    public static List<Administradora> AdministradorasCriadas = new List<Administradora>();
    
    public IEnumerable<Administradora> Read()
    {
        List<Administradora> lista = new List<Administradora>();
        string linha;
        
        try
        {
            StreamReader sr = new StreamReader("/home/carlos/Documents/Trabalho1/BancoDeDados/Administradora.txt");
            linha = sr.ReadLine();
            while (linha != null)
            {
                Administradora model = JsonSerializer.Deserialize<Administradora>(linha);
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

    public void Create(Administradora model)
    {
        try
        {
            StreamWriter sw = new StreamWriter("/home/carlos/Documents/Trabalho1/BancoDeDados/Administradora.txt", true);
            sw.WriteLine(JsonSerializer.Serialize(model));
            sw.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }

    public void Update(Administradora model)
    {
        List<Administradora> lista = Read().ToList();
        Administradora administradoraParaAtualizar = lista.Find(x => x.Id == model.Id);

        if (administradoraParaAtualizar != null)
        {
            administradoraParaAtualizar.NomeEmpresa = model.NomeEmpresa;
            administradoraParaAtualizar.Cnpj = model.Cnpj;
            
            StreamWriter sw = new StreamWriter("/home/carlos/Documents/Trabalho1/BancoDeDados/Administradora.txt");
            foreach (var administradora in lista)
            {
                sw.WriteLine(JsonSerializer.Serialize(administradora));
            }
            
            sw.Close();
        }
        else
        {
            Console.WriteLine("Administradora não encontrada!");
        }
    }

    public void Delete(int id)
    {
        List<Administradora> lista = Read().ToList();
        
        Administradora administradoraParaRemover = lista.Find(x => x.Id == id);

        if (administradoraParaRemover != null)
        {
            lista.Remove(administradoraParaRemover);
            StreamWriter sw = new StreamWriter("/home/carlos/Documents/Trabalho1/BancoDeDados/Administradora.txt");
            foreach (var administradora in lista)
            {
                sw.WriteLine(JsonSerializer.Serialize(administradora));
            }
            
            sw.Close();
        }
        else
        {
            Console.WriteLine("Administradora não encontrada");
        }
    }
}