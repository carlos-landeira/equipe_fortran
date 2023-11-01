using Trabalho1.Models;

namespace Trabalho1.Services;

public class CrudAdministradora: ICrud<Administradora>
{
    
    public IEnumerable<Administradora> Read()
    {
        throw new NotImplementedException();
    }

    public void Create(Administradora model)
    {
        string teste = Console.ReadLine();
        
        try
        {
            StreamWriter sw = new StreamWriter("/~/Documents/curso_csharp/Modulo4/Trabalho1/BancoDeDados/Administradora.txt", true);
            sw.WriteLine(teste);
            sw.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }

    public void Update(Administradora model)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}