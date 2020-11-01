using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SafeTech.Gton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        public OperationController()
        {
               
        }

        [HttpGet("{hospitalId}")]
        public async Task<IActionResult> ListarOperacoesPorHospital(int hospitalId)
        {
            return Ok();
        }

        [HttpGet("detalhes/{operacaoId}")]
        public async Task<IActionResult> BuscarOperacao(int operacaoId)
        { 
            return Ok();
        }
    }
}
