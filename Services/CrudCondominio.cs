using System.Text.Json;
using Trabalho1.Models;

namespace Trabalho1.Services;

public class CrudCondominio: ICrud<Condominio>
{
    public IEnumerable<Condominio> Read()
    {
        List<Condominio> lista = new List<Condominio>();
        string linha;
        
        try
        {
            StreamReader sr = new StreamReader("/home/carlos/Documents/Trabalho1/BancoDeDados/Condominio.txt");
            linha = sr.ReadLine();
            while (linha != null)
            {
                Condominio model = JsonSerializer.Deserialize<Condominio>(linha);
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

    public void Create(Condominio model)
    {
        try
        {
            StreamWriter sw = new StreamWriter("/home/carlos/Documents/Trabalho1/BancoDeDados/Condominio.txt", true);
            sw.WriteLine(JsonSerializer.Serialize(model));
            sw.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }

    public void Update(Condominio model)
    {
        List<Condominio> lista = Read().ToList();
        Condominio condominioParaAtualizar = lista.Find(x => x.Id == model.Id);

        if (condominioParaAtualizar != null)
        {
            condominioParaAtualizar.NomeEmpresa = model.NomeEmpresa;
            condominioParaAtualizar.Cnpj = model.Cnpj;
            
            StreamWriter sw = new StreamWriter("/home/carlos/Documents/Trabalho1/BancoDeDados/Condominio.txt");
            foreach (var condominio in lista)
            {
                sw.WriteLine(JsonSerializer.Serialize(condominio));
            }
            
            sw.Close();
        }
        else
        {
            Console.WriteLine("Condomínio não encontrado");
        }
    }

    public void Delete(int id)
    {
        List<Condominio> lista = Read().ToList();
        
        Condominio condominioParaRemover = lista.Find(x => x.Id == id);

        if (condominioParaRemover != null)
        {
            lista.Remove(condominioParaRemover);
            StreamWriter sw = new StreamWriter("/home/carlos/Documents/Trabalho1/BancoDeDados/Condominio.txt");
            foreach (var condominio in lista)
            {
                sw.WriteLine(JsonSerializer.Serialize(condominio));
            }
            
            sw.Close();
        }
        else
        {
            Console.WriteLine("Condomínio não encontrado");
        }
    }
}