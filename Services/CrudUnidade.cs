using System.Text.Json;
using Trabalho1.Models;

namespace Trabalho1.Services;

public class CrudUnidade<T>: ICrud<T> where T : Unidade
{
    public IEnumerable<T> Read()
    {
        List<T> lista = new List<T>();
        string linha;
        
        try
        {
            StreamReader sr = new StreamReader($"BancoDeDados/{typeof(T).Name}.txt");
            linha = sr.ReadLine();
            while (linha != null)
            {
                T model = JsonSerializer.Deserialize<T>(linha);
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

    public void Create(T model)
    {
        try
        {
            StreamWriter sw = new StreamWriter($"BancoDeDados/{typeof(T).Name}.txt", true);
            sw.WriteLine(JsonSerializer.Serialize(model));
            sw.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }

    public void Update(T model)
    {
        List<T> lista = Read().ToList();
        Unidade unidadeParaAtualizar = lista.Find(x => x.Id == model.Id);

        if (unidadeParaAtualizar != null)
        {
            unidadeParaAtualizar.Nome = model.Nome;
            unidadeParaAtualizar.Morador = model.Morador;
            
            StreamWriter sw = new StreamWriter($"BancoDeDados/{typeof(T).Name}.txt");
            foreach (var unidade in lista)
            {
                sw.WriteLine(JsonSerializer.Serialize(unidade));
            }
            
            sw.Close();
            // AtualizarNoCondominio(model);
        }
        else
        {
            Console.WriteLine("Unidade não encontrada");
        }
    }

    public void Delete(int id)
    {
        List<T> lista = Read().ToList();
        
        T unidadeParaRemover = lista.Find(x => x.Id == id);

        if (unidadeParaRemover != null)
        {
            lista.Remove(unidadeParaRemover);
            StreamWriter sw = new StreamWriter($"BancoDeDados/{typeof(T).Name}.txt");
            foreach (var unidade in lista)
            {
                sw.WriteLine(JsonSerializer.Serialize(unidade));
            }
            
            sw.Close();
        }
        else
        {
            Console.WriteLine("Unidade não encontrada");
        }
    }
    
    // private void AtualizarNoCondominio(Unidade model)
    // {
    //     CrudCondominio crudCondominio = new CrudCondominio();
    //     List<Condominio> condominios = crudCondominio.Read().ToList();
    //
    //     foreach (var condominio in condominios)
    //     {
    //         foreach (var unidade in condominio.Unidades)
    //         {
    //             if (unidade.Id == model.Id)
    //             {
    //                 unidade.Nome = model.Nome;
    //                 unidade.Morador = model.Morador;
    //                 
    //                 crudCondominio.Update(condominio);
    //             }
    //         }
    //     }
    // }
}