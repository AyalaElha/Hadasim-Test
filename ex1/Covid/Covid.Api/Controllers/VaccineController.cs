using Microsoft.AspNetCore.Mvc;
using Covid.Core;
using Covid.Core.Services;
using Covid.Service;
using Covid.Api.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Covid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineController : ControllerBase
    {
        private readonly IVaccineService _vaccineService;
        public VaccineController(IVaccineService vaccineService)
        {
            _vaccineService=vaccineService; 
        }
        // GET: api/<VaccineController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_vaccineService.GetVaccines());
        }

        // GET api/<VaccineController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
           var vaccine=_vaccineService.GetVaccineById(id);  
            if(vaccine == null) 
                return NotFound();  
            return Ok(vaccine); 
        }

        // POST api/<VaccineController>
        [HttpPost]
        public ActionResult Post([FromBody] VaccinePostModel vaccine)
        {
            var vaccineToAdd=new Vaccine { Date = vaccine.Date, ProducerId = vaccine.ProducerId, CovidDetailsId = vaccine.CovidDetailsId };
            return Ok(_vaccineService.AddVaccine(vaccineToAdd));
        }

        // PUT api/<VaccineController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Vaccine vaccine)
        {
            if (_vaccineService.GetVaccineById(id) == null)
                return NotFound();
            return Ok(_vaccineService.UpdateVaccine(id, vaccine));
        }

        // DELETE api/<VaccineController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if(_vaccineService.GetVaccineById(id)==null)
                return NotFound();             
            _vaccineService.DeleteVaccine(id);
            return Ok();     
        }
    }
}
