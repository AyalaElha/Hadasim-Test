using Covid.Api.Models;
using Covid.Core.Entities;
using Covid.Core.Services;
using Covid.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Covid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _producerService;
        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;    
        }
        // GET: api/<ProducerController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_producerService.GetProducers());
        }

        // GET api/<ProducerController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
           var producer=_producerService.GetProducerById(id);
            if(producer == null)    return NotFound();
            return Ok(producer);
        }

        // POST api/<ProducerController>
        [HttpPost]
        public ActionResult Post([FromBody] ProducerPostModel producer)
        {
            var producerToAdd= new Producer { Name = producer.Name ,Status=producer.Status};   
            return Ok(_producerService.AddProducer(producerToAdd)); 
        }

        // PUT api/<ProducerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProducerPostModel producer)
        {
            var producerToUpdate=new Producer { Name = producer.Name , Status=producer.Status};
            if(_producerService.GetProducerById(id) == null) return NotFound();
            return Ok(_producerService.UpdateProducer(id, producerToUpdate));   
        }
        //אין פעולת מחיקה אם נרצה למחוק נשנה את הסטטוס ללא פעיל
        // DELETE api/<ProducerController>/5
    //    [HttpDelete("{id}")]
    //    public ActionResult Delete(int id)
    //    {
    //        return NoContent();
    //    }
    }
}
