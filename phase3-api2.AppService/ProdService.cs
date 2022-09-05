using FluentValidation.Results;
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


        // add prod entry (putting new item in storage)
        public Prod AddProd(CreateProdDto createDto)
        {

            Prod prod = new Prod(createDto.Name, createDto.TimeExpire, DateTime.Now);

            return _prodRepository.InsertProd(prod);
        }


        // get ALL prod entries
        public List<Prod> GetProdList()
        {
            return _prodRepository.GetAllProd();
        }


        // add prod entry (taking exsisting item out)
        public Prod TakeProd(TakeProdDto takeProdDto)
        {

            Prod prod = _prodRepository.GetProd(takeProdDto.Id);

            //NO PROD FOUND
            if (prod == null)
            {
                throw new KeyNotFoundException("No prod entry with such Id.");
            }

            //PROD ALREADY HAVE FILLED INFO
            else if (prod.isWasted != null || prod.TimeTaken != null)
            {
                throw new ArgumentException("Given prod entry already filled out.");
            }

            prod.TimeTaken = DateTime.Now;
            prod.isWasted = takeProdDto.isWasted;

            return _prodRepository.UpdateProd(prod);
   
        }

    }
}
