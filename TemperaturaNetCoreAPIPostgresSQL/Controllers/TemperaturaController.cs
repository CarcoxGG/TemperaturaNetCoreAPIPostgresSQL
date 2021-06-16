using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperaturaNetCoreAPIPostgresSQL.Data.Repositories;
using TemperaturaNetCoreAPIPostgresSQL.Model;

namespace TemperaturaNetCoreAPIPostgresSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperaturaController : Controller
    {
        private readonly ITemperaturaRepository _temperaturaRepository;
        public TemperaturaController(ITemperaturaRepository temperaturaRepository)
        {
            _temperaturaRepository = temperaturaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTemps()
        {
            return Ok(await _temperaturaRepository.GetAllTemps());
        }

        [HttpGet("{ciudad}")]
        public async Task<IActionResult> GetTempDetails(string ciudad)
        {
            return Ok(await _temperaturaRepository.GetTempDetails(ciudad));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTemp([FromBody] Temperatura temp)
        {
            if (temp == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _temperaturaRepository.InsertTemp(temp);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTemp([FromBody] Temperatura temp)
        {
            if (temp == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _temperaturaRepository.UpdateTemp(temp);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemp(int id)
        {
            await _temperaturaRepository.DeleteTemp(new Temperatura { Id = id });

            return NoContent();
        }
    }
}
