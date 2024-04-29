namespace BulkyBook.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
  private readonly ApplicationDbContext _db;
  public UnitOfWork(ApplicationDbContext db)
  {
    _db = db;
  }

  public ICategoryRepository Category { get; set; }

  public void Save()
  {
    _db.SaveChanges();
  }
}
