using phase3_api2.Domain.Model;
using phase3_api2.Domain.DTO;

namespace phase3_api2.AppService
{
    public interface IProdService
    {
        public Prod AddProd(CreateProdDto createDto);
        public Prod TakeProd(TakeProdDto editDto);
        public List<Prod> GetProdList();

    }
}
