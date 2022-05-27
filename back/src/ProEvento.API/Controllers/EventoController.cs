using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEvento.API.Model;

namespace ProEvento.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _eventos = new Evento[]{
            
            new Evento(){
                eventoId = 1,
                tema = "Angular",
                local = "escola",
                lote = "100",
                qtdPessoas = 250,
                dataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
            },
            new Evento(){
                eventoId = 2,
                tema = "ASPNET",
                local = "escola",
                lote = "100",
                qtdPessoas = 250,
                dataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
            }        
        };
        public EventoController()
        {
       
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _eventos;
        }

         [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            IEnumerable<Evento> eventoEncontrado =  _eventos.Where(evento => evento.eventoId.Equals(id));
            if( eventoEncontrado.Count() == 0){
                return BadRequest("Evento não encontrado");
            }
            else{
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
