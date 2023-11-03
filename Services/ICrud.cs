using Trabalho1.Models;

namespace Trabalho1.Services;

public interface ICrud<T> where T: BaseModel
{
    public IEnumerable<T> Read();

    public void Create(T model);

    public void Update(T model);

    public void Delete(int id);
}