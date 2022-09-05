using phase3_api2.Domain.DTO;
using phase3_api2.Domain.Model;
using phase3_api2.Infrastructure;

namespace phase3_api2.AppService
{
    public class ProdService : IProdService
    {
        private readonly IProdRepository _prodRepository;

        //**CONSTRUCTOR**
        public ProdService(IProdRepository prodRepository)
        {
            _prodRepository = prodRepository;   
        }


        public Prod AddProd(CreateProdDto createDto)
        {
            Prod prod = new Prod(createDto.Name, createDto.TimeExpire, DateTime.UtcNow);

            return _prodRepository.InsertProd(prod);
        }

        public List<Prod> GetProdList()
        {
            return _prodRepository.GetAllProd();
        }

        public Prod TakeProd(TakeProdDto takeProdDto)
        {
            try
            {
                Prod prod = _prodRepository.GetProd(takeProdDto.Id);
                Prod updatedProd = new Prod(prod.Name, prod.TimeExpire, prod.TimeStored);

                updatedProd.TimeTaken = DateTime.Now;
                updatedProd.isWasted = takeProdDto.isWasted;

                _prodRepository.UpdateProd(updatedProd);

                return updatedProd;
            } 
            catch (KeyNotFoundException)
            {
                return null;
            }

            
            
        }

    }
}
