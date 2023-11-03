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
            StreamReader sr = new StreamReader("/home/carlos/Documents/Trabalho1/BancoDeDados/Morador.txt");
            linha = sr.ReadLine();
            while (linha != null)
            {
                var morador = linha.Split(';');
                Morador model = new Morador { Id = Convert.ToInt32(morador[0]), Nome = morador[1], DataNascimento = morador[2] };
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
            StreamWriter sw = new StreamWriter("/home/carlos/Documents/Trabalho1/BancoDeDados/Morador.txt", true);
            sw.WriteLine(model.ToString());
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
            
            StreamWriter sw = new StreamWriter("/home/carlos/Documents/Trabalho1/BancoDeDados/Morador.txt");
            foreach (var morador in lista)
            {
                sw.WriteLine(morador.ToString());
            }
            
            sw.Close();
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
            lista.Remove(moradorParaRemover);
            StreamWriter sw = new StreamWriter("/home/carlos/Documents/Trabalho1/BancoDeDados/Morador.txt");
            foreach (var morador in lista)
            {
                sw.WriteLine(morador.ToString());
            }
            
            sw.Close();
        }
        else
        {
            Console.WriteLine("Morador não encontrado");
        }
    }
}