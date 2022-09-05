using Microsoft.EntityFrameworkCore;
using phase3_api2.Domain.Model;

namespace phase3_api2.Infrastructure
{
    public class ProdRepository : IProdRepository
    {
        private readonly AppDbContext _appDbContext;

        //**CONSTRUCTOR**
        public ProdRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public Prod GetProd(int Id)
        {
            //Find prod with id 
            Prod prod = _appDbContext.Prods.SingleOrDefault(p => p.Id == Id);

            //**COULD RETURN NULL
            return prod;
        }

        public List<Prod> GetAllProd()
        {
            return _appDbContext.Prods.ToList();
        }

        public Prod InsertProd(Prod prod)
        {
            Prod addedProd = _appDbContext.Prods.Add(prod).Entity;
            SaveChanges();
            return addedProd;
        }

        public Prod UpdateProd(Prod prod)
        {
            Prod dbProd = _appDbContext.Prods.Find(prod.Id);

            if (dbProd == null)
            {
                return null;
            }

            dbProd.Name = prod.Name;
            dbProd.TimeStored = prod.TimeStored;
            dbProd.TimeExpire = prod.TimeExpire;
            dbProd.isWasted = prod.isWasted;
            dbProd.TimeTaken = prod.TimeTaken;

            SaveChanges();
            return dbProd;
        }

        public Prod DeleteProd(Prod prod)
        {
            Prod deletedProd = _appDbContext.Prods.Remove(prod).Entity;
            SaveChanges();
            return deletedProd;
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }

    }
}
