using Covid.Api.Models;
using Covid.Core.Entities;
using Covid.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Covid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidController : ControllerBase
    {
        private readonly ICovidService _covidService;
        public CovidController(ICovidService covidService)
        {
            _covidService = covidService;
        }
        // GET: api/<CovidDController>
        [HttpGet]
        public ActionResult Get()
        {
           return Ok(_covidService.GetCovids());    
        }

        // GET api/<CovidDController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var covid=_covidService.GetCovidById(id);
            if(covid == null)   
                return NotFound();
            return Ok(covid);
        }

        // POST api/<CovidDController>
        [HttpPost]
        public ActionResult Post([FromBody] CovidModel covid)
        {
            var covudToAdd = new CovidDetails { PositiveD = covid.PositiveD, RecoveryD = covid.RecoveryD, numOfVaccine = covid.numOfVaccine,MemberId=covid.MemberId };
            return Ok(_covidService.AddCovid(covudToAdd));
        }

        // PUT api/<CovidDController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CovidModel covid)
        {
            var covudToUpdate = new CovidDetails { PositiveD = covid.PositiveD, RecoveryD = covid.RecoveryD, numOfVaccine = covid.numOfVaccine, MemberId = covid.MemberId };
            if (_covidService.GetCovidById(id)==null) return NotFound();
            return Ok(_covidService.UpdateCovid(id, covudToUpdate));

        }

        // DELETE api/<CovidDController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if(_covidService.GetCovidById(id)== null) return NotFound();
            _covidService.DeleteCovid(id);
            return Ok();
        }
    }
}
