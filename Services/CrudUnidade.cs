using Trabalho1.Models;

namespace Trabalho1.Services;

public class CrudUnidade<T>: ICrud<T> where T: Unidade, new()
{
    public IEnumerable<T> Read()
    {
        List<T> lista = new List<T>();
        string linha;
        
        try
        {
            StreamReader sr = new StreamReader($"/home/carlos/Documents/Trabalho1/BancoDeDados/{typeof(T).Name}.txt");
            linha = sr.ReadLine();
            while (linha != null)
            {
                var unidade = linha.Split(';');
                T model = new T
                {
                    Id = Convert.ToInt32(unidade[0]),
                    Nome = unidade[1],
                    Morador = Morador.FindById(int.Parse(unidade[2]))
                };
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
            StreamWriter sw = new StreamWriter($"/home/carlos/Documents/Trabalho1/BancoDeDados/{typeof(T).Name}.txt", true);
            sw.WriteLine(model.ToString());
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
            
            StreamWriter sw = new StreamWriter($"/home/carlos/Documents/Trabalho1/BancoDeDados/{typeof(T).Name}.txt");
            foreach (var unidade in lista)
            {
                sw.WriteLine(unidade.ToString());
            }
            
            sw.Close();
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
            StreamWriter sw = new StreamWriter($"/home/carlos/Documents/Trabalho1/BancoDeDados/{typeof(T).Name}.txt");
            foreach (var unidade in lista)
            {
                sw.WriteLine(unidade.ToString());
            }
            
            sw.Close();
        }
        else
        {
            Console.WriteLine("Unidade não encontrada");
        }
    }
}