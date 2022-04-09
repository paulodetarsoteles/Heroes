using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly HeroiContext _context; 
        public ValuesController(HeroiContext context)
        {
            _context = context; 
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            var listHeroi = (from heroi 
                             in _context.Herois 
                             select heroi).
                             ToList(); 

            return Ok(listHeroi);
        }

        // GET api/values/5
        [HttpGet("{nameHero}")]
        public ActionResult Get(string nameHero)
        {
            var heroi = new Heroi { Nome = nameHero }; 
            
            _context.Herois.Add(heroi);
            _context.SaveChanges();
            
            return Ok(); 
        }

        // GETADDRANGE api/values/AddRange
        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            _context.AddRange(
                new Heroi { Nome = "Capitão América"},
                new Heroi { Nome = "Doutor Estranho"},
                new Heroi { Nome = "Pantera Negra"},
                new Heroi { Nome = "Viúva Negra"},
                new Heroi { Nome = "Hulk"},
                new Heroi { Nome = "Gavião Arqueiro"},
                new Heroi { Nome = "Capitã Marvel"}
            );
            _context.SaveChanges();
            return Ok();
        }

        // GET api/values/Atualizar/4
        [HttpGet("Atualizar/{idHero}")]
        public ActionResult Get(int Id)
        {
            var heroi = _context.Herois
                        .Where(h => h.Id == 4)
                        .FirstOrDefault();
            heroi.Nome = "Homem Aranha"; 

            
            _context.SaveChanges();

            return Ok();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/Delete/5
        [HttpGet("Delete/{id}")]
        public void Delete(int id)
        {
            var heroi = _context.Herois
                                .Where(h => h.Id == id)
                                .FirstOrDefault(); 
            _context.Remove(heroi);
            _context.SaveChanges(); 
        }
    }
}
