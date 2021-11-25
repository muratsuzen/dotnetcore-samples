using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reppat.Business.Abstract;
using reppat.Entities.Concrete;

namespace reppat.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        IPersonalService _personalService;

        public PersonalController(IPersonalService personalService)
        {
            _personalService = personalService;
        }

        [HttpPost]
        public ActionResult Add(Personal personal)
        {
            if (personal == null)
                throw new ArgumentNullException(nameof(personal));

            try
            {
                _personalService.Add(personal);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message); 
            }
            
        }

        [HttpPut]
        public ActionResult Update(Personal personal)
        {
            if (personal == null)
                throw new ArgumentNullException(nameof(personal));

            try
            {
                _personalService.Update(personal);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }

        }

        [HttpGet("Get/{personalId}")]
        public Personal Get(int personalId)
        {
            return _personalService.Get(personalId);

        }

        [HttpGet]
        public List<Personal> GetList()
        {
           return _personalService.GetList();

        }
    }
}
