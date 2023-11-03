using Trabalho1.Services;

namespace Trabalho1.Models;

public class Morador: BaseModel
{
    public string Nome { get; set; }
    public string DataNascimento { get; set; }
    
    private static int ProximoId;

    public Morador()
    {
        this.Id = ProximoId++;
    }

    public static Morador FindById(int id)
    {
        CrudMorador crudMorador = new CrudMorador();
        List<Morador> moradores = crudMorador.Read().ToList();

        return moradores.Find(x => x.Id == id) ?? new Morador();
    }

    public string ToString()
    {
        return base.ToString() + $";{Nome};{DataNascimento}";
    }
}