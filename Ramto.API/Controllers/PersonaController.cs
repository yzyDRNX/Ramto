using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ramto.Lib.Interfaces;
using Ramto.Modelos.Request;
using Ramto.Modelos.Response;

//namespace SIIC.Migrantes.API.Controllers
//{
//    [Route("api/Persona")]
//    [ApiController]
//    public class PersonaController : ControllerBase
//    {
//        #region Propiedades
//        private readonly IPersona _persona;
//        #endregion

//        public PersonaController(IPersona persona)
//        {
//            _persona = persona;
//        }

//        #region Catalogos
//        [HttpGet("ObtenerEstadosUnidos")]
//        public async Task<IActionResult> ObtenerEstadosUnidos()
//        {
//            var response = new Apiresponse<List<EstadosResponse>>();
//            try
//            {
//                response = await _persona.ObtenerEstadosUnidos();
//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                response.Exito = false;
//                response.Mensaje = e.Message;
//                return BadRequest(response);
//            }
//        }

//        [HttpGet("ObtenerMunicipiosChiapas")]
//        public async Task<IActionResult> ObtenerMunicipiosChiapas()
//        {
//            var response = new Apiresponse<List<EstadosResponse>>();
//            try
//            {
//                response = await _persona.ObtenerMunicipiosChiapas();
//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                response.Exito = false;
//                response.Mensaje = e.Message;
//                return BadRequest(response);
//            }
//        }

//        [HttpGet("ObtenerColoniasChiapas")]
//        public async Task<IActionResult> ObtenerColoniasChiapas(string Nombre)
//        {
//            var response = new Apiresponse<List<EstadosResponse>>();
//            try
//            {
//                response = await _persona.ObtenerColoniasChiapas(Nombre);
//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                response.Exito = false;
//                response.Mensaje = e.Message;
//                return BadRequest(response);
//            }
//        }

//        [HttpGet("ObtenerOficios")]
//        public async Task<IActionResult> ObtenerOficios()
//        {
//            var response = new Apiresponse<List<EstadosResponse>>();
//            try
//            {
//                response = await _persona.ObtenerOficios();
//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                response.Exito = false;
//                response.Mensaje = e.Message;
//                return BadRequest(response);
//            }
//        }
//        #endregion


//        [HttpPost("AgregarPersona")]
//        public async Task<IActionResult> AgregarPersona([FromBody] PersonaRequest P)
//        {
//            var response = new SimpleResponse();
//            try
//            {
//                response = await _persona.AgregarPersona(P);
//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                response.Exito = false;
//                response.Mensaje = e.Message;
//                return BadRequest(response);
//            }
//        }

//        [HttpPost("AgregarResidencia")]
//        public async Task<IActionResult> AgregarResidencia([FromBody] ResidenciaPersonaRequest P)
//        {
//            var response = new SimpleResponse();
//            try
//            {
//                response = await _persona.AgregarResidenciaPersona(P);
//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                response.Exito = false;
//                response.Mensaje = e.Message;
//                return BadRequest(response);
//            }
//        }
//        [HttpPost("AgregarFamiliar")]
//        public async Task<IActionResult> AgregarFamiliar([FromBody] FamiliarRequest P)
//        {
//            var response = new SimpleResponse();
//            try
//            {
//                response = await _persona.AgregarFamiliar(P);
//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                response.Exito = false;
//                response.Mensaje = e.Message;
//                return BadRequest(response);
//            }
//        }
//        [HttpPost("ObtenerListaFamiliar")]
//        public async Task<IActionResult> ObtenerListaFamiliar([FromBody] FamiliarRequest P)
//        {
//            var response = new SimpleResponse();
//            try
//            {
//                response = await _persona.ObtenerListaFamiliar(P.IdPersona);
//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                response.Exito = false;
//                response.Mensaje = e.Message;
//                return BadRequest(response);
//            }
//        }
//        [HttpGet("ObtenerPersonas")]
//        public async Task<IActionResult> ObtenerPersonas(int paginaActual, int cantidad)
//        {
//            var response = new Apiresponse<List<PersonaRequest>>();
//            try
//            {
//                response = await _persona.ObtenerListaPersonasCapturadas(paginaActual, cantidad);
//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                response.Exito = false;
//                response.Mensaje = e.Message;
//                return BadRequest(response);
//            }
//        }
//        [HttpPost("ReporteCaptura")]
//        public async Task<IActionResult> ReporteCaptura([FromBody] Guid IdPersona)
//        {
//            string reporte = string.Empty;
//            try
//            {
//                reporte = await _persona.ReporteInformacionCapturada(IdPersona);
//                return Ok(reporte);
//            }
//            catch (Exception e)
//            {

//                return BadRequest(e.Message);
//            }
//        }

//        //Graficar el genero de las personas capturadas
//        [HttpGet("ObtenerDatosGenero")]
//        public async Task<IActionResult> ObtenerDatosGenero()
//        {
//            var response = new Apiresponse<List<GeneroResponse>>();
//            try
//            {
//                response = await _persona.ObtenerDatosGenero();
//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                response.Exito = false;
//                response.Mensaje = e.Message;
//                return BadRequest(response);
//            }
//        }

//        [HttpGet("ObtenerDatosOficio")]
//        public async Task<IActionResult> ObtenerDatosOficio(int idOficio)
//        {
//            var response = new Apiresponse<List<OficioResponse>>();
//            try
//            {
//                response = await _persona.ObtenerDatosOficio(idOficio);
//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                response.Exito = false;
//                response.Mensaje = e.Message;
//                return BadRequest(response);
//            }
//        }

//        [HttpGet("ObtenerEstadoExtranjero")]
//        public async Task<IActionResult> ObtenerEstadoExtranjero(int idEstadoExtranjero)
//        {
//            var response = new Apiresponse<List<ExtranjeroResponse>>();
//            try
//            {
//                response = await _persona.ObtenerEstadoExtranjero(idEstadoExtranjero);
//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                response.Exito = false;
//                response.Mensaje = e.Message;
//                return BadRequest(response);
//            }
//        }

//        [HttpGet("ObtenerDatosMenoresEdad")]
//        public async Task<IActionResult> ObtenerDatosMenoresEdad(int edadMin, int edadMax)
//        {
//            var response = new Apiresponse<List<MenoresEdadResponse>>();
//            try
//            {
//                response = await _persona.ObtenerDatosMenoresEdad(edadMin, edadMax);
//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                response.Exito = false;
//                response.Mensaje = e.Message;
//                return BadRequest(response);
//            }
//        }

//        [HttpGet("ObtenerDatosGruposEdad")]
//        public async Task<IActionResult> ObtenerDatosGruposEdad()
//        {
//            var response = new Apiresponse<List<GruposEdadResponse>>();
//            try
//            {
//                response = await _persona.ObtenerDatosGruposEdad();
//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                response.Exito = false;
//                response.Mensaje = e.Message;
//                return BadRequest(response);
//            }
//        }

//        [HttpPost("AgregarUsuario")]
//        public async Task<IActionResult> AgregarUsuario([FromBody] AgregarUsuarioRequest U)
//        {
//            var response = new SimpleResponse();
//            try
//            {
//                response = await _persona.AgregarUsuario(U);
//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                response.Exito = false;
//                response.Mensaje = e.Message;
//                return BadRequest(response);
//            }
//        }

//        [HttpGet("ObtenerListaUsuarios")]
//        public async Task<IActionResult> ObtenerListaUsuarios()
//        {
//            var response = new Apiresponse<List<ObtenerUsuarioResponse>>();
//            try
//            {
//                response = await _persona.ObtenerListaUsuarios();
//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                response.Exito = false;
//                response.Mensaje = e.Message;
//                return BadRequest(response);
//            }

//        }
//        [HttpPost("EliminarUsuario")]
//        public async Task<IActionResult> EliminarUsuario([FromBody] EliminarUsuarioRequest U)
//        {
//            var response = new SimpleResponse();
//            try
//            {
//                response = await _persona.EliminarUsuario(U);
//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                response.Exito = false;
//                response.Mensaje = e.Message;
//                return BadRequest(response);
//            }
//        }

//        [HttpPost("ActualizarUsuario")]
//        public async Task<IActionResult> ActualizarUsuario([FromBody] ActualizarUsuarioRequest U)
//        {
//            var response = new SimpleResponse();
//            try
//            {
//                response = await _persona.ActualizarUsuario(U);
//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                response.Exito = false;
//                response.Mensaje = e.Message;
//                return BadRequest(response);
//            }
//        }

//        [HttpGet("Exportar")]
//        public async Task<IActionResult> Exportar()
//        {

//            try
//            {
//                var response = await _persona.Exportar();
//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                return BadRequest();
//            }
//        }

//        //[HttpGet("GenerarExcel")]
//        //public async Task<IActionResult> GenerarExcel()
//        //{

//        //    try
//        //    {
//        //        string response = await _persona.GenerarExcel();
//        //        return Ok(response);
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        // Manejar errores y devolver un mensaje descriptivo
//        //        return BadRequest(new { Error = e.Message });
//        //    }
//        //}
//    }
//}
