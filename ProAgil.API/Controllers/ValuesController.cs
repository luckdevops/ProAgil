using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.API.Data;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        //public ActionResult<IEnumerable<Evento>> Get()
        //public IActionResult Get()
        public async Task<IActionResult> Get()
        {
            try
            { 
                var results = await _context.Eventos.ToListAsync();
               
                return Ok(results);
            }
            catch(System.Exception)
            {
                //throw;
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        //public ActionResult<Evento> Get(int id)
        public async Task<IActionResult> Get(int id)
        {
            /*/return new Evento[] {
                 new Evento() {
                     EventoId = 1,
                     Tema = "Angular e .Net Core",
                     Local = "Belo Horizonte",
                     Lote = "1º Lote",
                     QtdPessoas = 150,
                     DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                 },
                 new Evento() {
                     EventoId = 2,
                     Tema = "Angular e Suas Novidades",
                     Local = "Salvador",
                     Lote = "2º Lote",
                     QtdPessoas = 300,
                     DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
                 },
              }.FirstOrDefault(x => x.EventoId == id);*/

            try
            { 
                var results = await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
            
                return Ok(results);
            }
              catch(System.Exception)
            {
                //throw;
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
            //return _context.Eventos.FirstOrDefault(x => x.EventoId == id);
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

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
