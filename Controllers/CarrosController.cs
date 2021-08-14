using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aec_webapi_entity_framework.Models;
using aec_webapi_entity_framework.Servicos;

namespace aec_webapi_entity_framework.Controllers
{
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly DbContexto _context;

        public CarrosController(DbContexto context)
        {
            _context = context;
        }

        // GET: Carros
        [HttpGet]
        [Route("/carros")]
        public async Task<IActionResult> Index()
        {
            // var dbContexto = _context.Carros.Where(c => c.Nome == "Gol");
            var dbContexto = _context.Carros
            return StatusCode(200, await dbContexto.ToListAsync());
        }

        [HttpPost]
        [Route("/carros")]
        [Route("/cars")]
        public async Task<IActionResult> Create([Bind("Id,Nome,Modelo,MarcaId,Ano")] Carro carro)
        {
            _context.Add(carro);
            await _context.SaveChangesAsync();
            return StatusCode(201, carro);
        }

        [HttpPut]
        [Route("/carros/{id}")]
        [Route("/cars/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Modelo,MarcaId,Ano")] Carro carro)
        {
            if (id != carro.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(carro);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(carro.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(200, carro);
        }

        [HttpGet]
        [Route("/carros/{id}")]
        public async Task<Carro> Get(int id)
        {
            return await _context.Carros.FindAsync(id);
        }

        [HttpDelete]
        [Route("/carros/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool CarroExists(int id)
        {
            return _context.Carros.Any(e => e.Id == id);
        }
    }
}
