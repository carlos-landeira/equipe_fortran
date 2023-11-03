namespace Trabalho1.Models;

public class BaseModel
{
    public int Id { get; set; }

    public string ToString()
    {
        return $"{Id}";
    }
}