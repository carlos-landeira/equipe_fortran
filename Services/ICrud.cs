namespace Trabalho1;

public interface ICrud<T>
{
    public IEnumerable<T> Read();

    public void Create(T model);

    public void Update(T model);

    public void Delete(int id);
}