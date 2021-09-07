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
    public class TruckModelController : ControllerBase
    {
        private readonly IService<TruckModel> service;

        public TruckModelController(IService<TruckModel> service)
        {
            this.service = service;
        }

        // GET: api/<TruckModelController>
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

        // GET api/<TruckModelController>/5
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

        // POST api/<TruckModelController>
        //[HttpPost]
        //public IActionResult Post([FromBody] TruckModel value)
        //{
        //    return Ok(service.Post(value));
        //}

        // PUT api/<TruckModelController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(long id, [FromBody] TruckModel value)
        //{
        //    return Ok(service.Put(id, value));
        //}

        // DELETE api/<TruckModelController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(long id)
        //{
        //    return Ok(service.Delete(id));
        //}
    }
}
