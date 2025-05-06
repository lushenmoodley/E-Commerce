using ECommerceApp.Data;
using ECommerceApp.Repository.IRespository;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerceApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        } 

        public Category Create(Category obj)
        {
            _db.Category.Add(obj);
            _db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var obj = _db.Category.FirstOrDefault(u => u.Id == id);
            
            if(obj!=null)
            {
                _db.Category.Remove(obj);
                return _db.SaveChanges()>0;
            }

            return false;
        }

        public Category Get(int id)
        {
            var obj = _db.Category.FirstOrDefault(u => u.Id == id);

            if(obj==null)
            {
                return new Category();
            }

            return obj;
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Category.ToList();
        }

        public Category Update(Category obj)
        {
            var objFromDB = _db.Category.FirstOrDefault(x => x.Id == obj.Id);

            if(objFromDB is not null)
            {
                objFromDB.Name = obj.Name;
                _db.Category.Update(objFromDB);
                _db.SaveChanges();
                return objFromDB;
            }

            return obj;
        }
    }
}
    