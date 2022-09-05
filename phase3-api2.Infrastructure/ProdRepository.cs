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

            //If not found raise exception
            if (prod == null)
            {
                throw new KeyNotFoundException("Prod with Id not found.");
            }
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
            Prod updatedProd = _appDbContext.Prods.Update(prod).Entity;
            SaveChanges();
            return updatedProd;
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
