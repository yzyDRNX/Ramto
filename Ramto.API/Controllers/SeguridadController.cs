using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Ramto.Lib.Interfaces;
using Ramto.Modelos.Request;
using Ramto.Modelos.Response;

namespace Ramto.API.Controllers
{
    [Route("api/Seguridad")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        #region Propiedades
        private readonly ISeguridad _seguidad;
        #endregion

        public SeguridadController(ISeguridad seguridad)
        {
            _seguidad = seguridad;
        }

        [HttpPost("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion([FromBody] UsuarioRequest U)
        {
            var response = new Apiresponse<UsuarioResponse>();

            try
            {
                response = await _seguidad.Login(U);
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Exito = false;
                response.Mensaje = e.Message;
                return BadRequest(response);
            }
        }
    }
}
