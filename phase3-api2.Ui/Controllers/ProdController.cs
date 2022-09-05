using Microsoft.AspNetCore.Mvc;
using phase3_api2.AppService;
using phase3_api2.Domain.DTO;
using phase3_api2.Domain.Model;

namespace phase3_api2.Ui.Controllers
{
    [ApiController]
    public class ProdController : Controller
    {
        private readonly IProdService _prodService;

        //**CONSTRUCTOR**
        public ProdController(IProdService prodService)
        {
            _prodService = prodService;
        }

        [HttpGet]
        [Route("getAllProdEntries")]
        public ActionResult<List<Prod>> GetAllProdInfo()
        {
            return Ok(_prodService.GetProdList());
        }

        [HttpPost]
        [Route("addProdEntryStore")]
        public ActionResult<Prod> addProdEntryStore(CreateProdDto createDto)
        {
            Prod addedProd = _prodService.AddProd(createDto);

            return Ok(addedProd);   
        }

        [HttpPut]
        [Route("addProdEntryTake")]
        public ActionResult<Prod> addProdEntryTake(TakeProdDto takeDto)
        {
            Prod modedProd = _prodService.TakeProd(takeDto);
            if (modedProd == null)
            {
                return BadRequest("No product with given ID");
            } else
            {
                return Ok(modedProd);
            }
        }
    }
}
