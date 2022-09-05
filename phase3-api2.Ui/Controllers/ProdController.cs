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

        /// <summary>
        /// Get a list of all information stored.
        /// </summary>
        [HttpGet]
        [Route("getAllProdEntries")]
        public ActionResult<List<Prod>> GetAllProdInfo()
        {
            return Ok(_prodService.GetProdList());
        }

        /// <summary>
        /// Add a new entry about a product being stored, must have a name and expiry date.
        /// </summary>
        /// <remarks>
        /// Response contain information of the entry stored, NOTE: id might be useful for locating this entry later.
        /// </remarks>
        [HttpPost]
        [Route("addProdEntryStore")]
        public ActionResult<Prod> addProdEntryStore(CreateProdDto createDto)
        {
            try
            {
                Prod addedProd = _prodService.AddProd(createDto);
                return Ok(addedProd);
            }
            
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
               
        }

        /// <summary>
        /// Add information about the removal of a product stored (located with Id), must state if it was wasted.
        /// </summary>
        /// 
        [HttpPut]
        [Route("addProdEntryTake")]
        public ActionResult<Prod> addProdEntryTake(TakeProdDto takeDto)
        {
            try
            {
                Prod modedProd = _prodService.TakeProd(takeDto);
                return Ok(modedProd);
            } 
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }
    }
}
