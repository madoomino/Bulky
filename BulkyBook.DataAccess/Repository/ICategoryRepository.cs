using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository;

public interface ICategoryRepository : IRepository<Category>
{
    void Save();
    void Update(Category obj);
}
