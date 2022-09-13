using phase3_api2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phase3_api2.Domain.Interface
{
    public interface IProdRepository
    {
        public List<Prod> GetAllProd();

        public Prod GetProd(int Id);

        public Prod InsertProd (Prod prod);

        public Prod UpdateProd(Prod prod);

        public Prod DeleteProd(Prod prod);

        public void SaveChanges();
    }
}
