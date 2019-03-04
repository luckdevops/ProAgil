using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalestranteController : ControllerBase
    {
        public IProAgilRepository _repo { get; }

        public PalestranteController(IProAgilRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            { 
                var results = await _repo.GetAllPalestranteAsync(true);
               
                return Ok(results);
            }
            catch(System.Exception)
            {
                //throw;
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
            
        }        

        [HttpGet("{PalestranteId}")]
        public async Task<IActionResult> Get(int PalestranteId)
        {
            try
            { 
                var results = await _repo.GetAllPalestranteAsync(PalestranteId, false);
               
                return Ok(results);
            }
            catch(System.Exception)
            {
                //throw;
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet("getByName/{PalestranteNome}")]
        public async Task<IActionResult> Get(string PalestranteNome)
        {
            try
            { 
                var results = await _repo.GetAllPalestranteAsyncByName(PalestranteNome, false);
               
                return Ok(results);
            }
            catch(System.Exception)
            {
                //throw;
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Palestrante model)
        {
            try
            { 
                _repo.Add(model);

                if (await _repo.SaveChangeAsync())
                {
                    return Created($"/api/palestrante/{model.Id}", model);
                }
            }
            catch(System.Exception)
            {
                //throw;
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int PalestranteId, Palestrante model)
        {
            try
            { 
                var palestrante = await _repo.GetAllPalestranteAsync(PalestranteId, false);

                if (palestrante == null) return NotFound();
                
                _repo.Update(palestrante);

                if (await _repo.SaveChangeAsync())
                {
                    return Created($"/api/palestrante/{model.Id}", model);
                }
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int PalestranteId)
        {
            try
            { 
                var palestrante = await _repo.GetAllPalestranteAsync(PalestranteId, false);

                if (palestrante == null) return NotFound();
                
                _repo.Delete(palestrante);

                if (await _repo.SaveChangeAsync())
                {
                    return Ok();
                }
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }     
    }
}