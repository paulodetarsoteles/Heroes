using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Heroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        private readonly IEFCoreRepository _repository;
        public HeroiController(IEFCoreRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<HeroiController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var herois = await _repository.GetAllHerois();
                return Ok(herois);
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<HeroiController>/5
        [HttpGet("{id}", Name ="GetHeroi")]
        public async Task <IActionResult> Get(int id)
        {
            try
            {
                var herois = await _repository.GetHeroiById(id, false); 
                return Ok(herois);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST api/<HeroiController>
        [HttpPost]
        public async Task<IActionResult> Post(Heroi model)
        {
            try
            {
                _repository.Add(model);
                if (await _repository.SaveChangeAsync())
                {
                    return Ok("Heroi Adicionado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Não Salvou");
        }

        // PUT api/<HeroiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Heroi model)
        {
            try
            {
                var heroi = await _repository.GetHeroiById(id);
                if (heroi != null)
                {
                    _repository.Update(model);
                    if (await _repository.SaveChangeAsync())
                        return Ok("Heroi atualizado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Não Atualizou");
        }

        // DELETE api/<HeroiController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var heroi = await _repository.GetHeroiById(id);
                if (heroi != null)
                {
                    _repository.Delete(heroi);
                    if(await _repository.SaveChangeAsync())
                    return Ok("Heroi Deletado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Não Deletou");
        }
    }
}