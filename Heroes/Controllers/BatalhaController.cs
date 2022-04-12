using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Heroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : ControllerBase
    {
        private readonly HeroiContext _context;
        public BatalhaController(HeroiContext context)
        {
            _context = context;
        }
        // GET: api/<BatalhaController1>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Batalha());
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<BatalhaController1>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                if(_context.Batalhas.Find(id) != null)
                {
                    return Ok(_context.Batalhas
                        .Where(h => h.Id == id)
                        .FirstOrDefault());
                }
                return Ok("Batalha não encontrada"); 
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST api/<BatalhaController1>
        [HttpPost]
        public ActionResult Post(Batalha model)
        {
            try
            {
                _context.Batalhas.Add(model);
                _context.SaveChanges();
                return Ok("Batalha Adicionada");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // PUT api/<BatalhaController1>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Batalha model)
        {
            try
            {
                if (_context.Batalhas.AsNoTracking().FirstOrDefault(b => b.Id == id) != null)
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    return Ok("Batalha atualizada!");
                }

                return Ok("Não Encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // DELETE api/<BatalhaController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
