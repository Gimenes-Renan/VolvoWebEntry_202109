using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volvo_API.Models;
using Volvo_API.Repository.Context;
using Volvo_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Volvo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        private readonly IService<Truck> service;

        public TruckController(IService<Truck> service)
        {
            this.service = service;
        }

        // GET: api/<TruckController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(service.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // GET api/<TruckController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                return Ok(service.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<TruckController>
        [HttpPost]
        public IActionResult Post([FromBody] Truck value)
        {
            try
            {
                return Ok(service.Post(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<TruckController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Truck value)
        {
            try
            {
                return Ok(service.Put(id, value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<TruckController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            service.Delete(id);
            return NoContent();
        }
    }
}
