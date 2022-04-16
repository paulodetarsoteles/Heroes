using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Heroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : ControllerBase
    {
        private readonly IEFCoreRepository _repository;
        public BatalhaController(IEFCoreRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<BatalhaController1>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var batalhas = await _repository.GetAllBatalhas();
                return Ok(batalhas);
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<BatalhaController1>/5
        [HttpGet("{id}", Name = "GetBatalha")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var batalhas = await _repository.GetBatalhaById(id, true); 
                return Ok(batalhas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST api/<BatalhaController1>
        [HttpPost]
        public async Task<IActionResult> Post(Batalha model)
        {
            try
            {
                _repository.Add(model);
                if (await _repository.SaveChangeAsync())
                {
                    return Ok("Batalha Adicionada");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Não Salvou");
        }

        // PUT api/<BatalhaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Batalha model)
        {
            try
            {
                var batalha = await _repository.GetBatalhaById(id);
                if (batalha != null)
                {
                    _repository.Update(model);
                    if (await _repository.SaveChangeAsync())
                        return Ok("Batalha atualizada");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Não Atualizou");
        }

        // DELETE api/<BatalhaController1>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try 
            {
                var batalha = await _repository.GetBatalhaById(id); 
                if (batalha != null)
                {
                    _repository.Delete(batalha);
                    if(await _repository.SaveChangeAsync())
                    return Ok("Batalha Deletada");
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