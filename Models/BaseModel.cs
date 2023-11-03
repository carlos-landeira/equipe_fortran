namespace Trabalho1.Models;

public class BaseModel
{
    public int Id { get; set; }

    public override string ToString()
    {
        return $"{Id}";
    }
}