using DesafioCDB.Domain.Dtos.Requests;
using DesafioCDB.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCDB.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  
    public class CdbController : ControllerBase
    {
        private readonly ICdbService _cdbService;
                
        public CdbController(ICdbService cdbService)
        {
            _cdbService = cdbService;
        }

        [HttpPost]
        [Route("calcular")]  
        public IActionResult CalcularCDB([FromBody] CdbRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {                
                var response = _cdbService.CalcularCDB(request);

                return Ok(response);
            }
            catch (Exception ex)
            {                
                return StatusCode(500, "Ocorreu um erro interno no servidor: " + ex.Message);
            }
        }
    }
}