using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private static readonly Item[] Items = new Item[]{
            new Item{
                Id = 1,
                Code = "X001",
                Name = "Computer",
                Image = "/img/computer.jpg"
            },
            new Item{
                Id = 2,
                Code = "X002",
                Name = "Telephone",
                Image = "/img/telephone.jpg"
            },
            new Item{
                Id = 3,
                Code = "X003",
                Name = "Watch",
                Image = "/img/watch.jpg"
            },
        };

        

        [HttpGet("Get")]
        public IEnumerable<Item> Get()
        {
            return Items.ToList();
        }

        [HttpGet("Get/{id:int}")]
        public Item Get(int id)
        {
            return Items.FirstOrDefault(x=>x.Id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Item item)
        {
            try
            {
                return Ok("Success!");
            }
            catch (System.Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Item item)
        {
            try
            {
                return Ok("Success!");
            }
            catch (System.Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok("Success!");
            }
            catch (System.Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
