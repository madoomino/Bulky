using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository;

public class CategoryRepository(ApplicationDbContext db) : Repository<Category>(db), ICategoryRepository
{
    private ApplicationDbContext _db = db;
    public void Save()
    {
        _db.SaveChanges();
    }

    public void Update(Category obj)
    {
        _db.Update(obj);
    }
}