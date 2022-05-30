using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEvento.API.Data;
using ProEvento.API.Model;

namespace ProEvento.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly DataContext _context;
        public EventosController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            Evento eventoEncontrado = _context.Eventos.FirstOrDefault(evento => evento.eventoId.Equals(id));
            if (eventoEncontrado == null)
            {
                return BadRequest("Evento não encontrado");
            }
            else
            {
                return Ok(eventoEncontrado);
            }
        }

        [HttpPost]
        public string Post()
        {
            return "POST";
        }


        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Put = {id}";
        }


        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"delete = {id}";
        }
    }
}
