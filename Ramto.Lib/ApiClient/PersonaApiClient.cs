//using Ramto.Lib.OS;
//using Ramto.Modelos.Request;
//using Ramto.Modelos.Response;
//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Text;

//namespace Ramto.Lib.ApiClient
//{
//    public class PersonaApiClient: WebApiClient
//    {
//        public PersonaApiClient(): base(SettingsValuesClient.CurrentApiValues.UrlWebApi, "Persona")//base(SettingsValuesClient.CurrentApiValues.UrlWebApi, "Persona")
//        {
            
//        }

//        public async Task<(HttpStatusCode StatusCode, SimpleResponse result)> AgregarPersona(PersonaRequest data)
//        {
//            try
//            {
//                return await CallPostAsync<PersonaRequest, SimpleResponse>("AgregarPersona", data);
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError, new SimpleResponse
//                {
//                    // Puedes personalizar el mensaje de error según tus necesidades
//                    Mensaje = ex.Message,
//                    Exito = false
//                });
//            }
//        }
//        public async Task<(HttpStatusCode StatusCode, SimpleResponse result)> AgregarResidenciaPersona(ResidenciaPersonaRequest data)
//        {
//            try
//            {
//                return await CallPostAsync<ResidenciaPersonaRequest, SimpleResponse>("AgregarResidencia", data);
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError, new SimpleResponse
//                {
//                    // Puedes personalizar el mensaje de error según tus necesidades
//                    Mensaje = ex.Message,
//                    Exito = false
//                });
//            }
//        }
//        public async Task<(HttpStatusCode StatusCode, SimpleResponse result)> AgregarFamiliarPersona(FamiliarRequest data)
//        {
//            try
//            {
//                return await CallPostAsync<FamiliarRequest, SimpleResponse>("AgregarFamiliar", data);
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError, new SimpleResponse
//                {
//                    // Puedes personalizar el mensaje de error según tus necesidades
//                    Mensaje = ex.Message,
//                    Exito = false
//                });
//            }
//        }
//        public async Task<(HttpStatusCode StatusCode, Apiresponse<List<FamiliarRequest>> result)> ObtenerListaFamiliarPersona(FamiliarRequest data)
//        {
//            try
//            {
//                return await CallPostAsync<FamiliarRequest,Apiresponse < List < FamiliarRequest >>> ("ObtenerListaFamiliar", data);
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError,new Apiresponse<List<FamiliarRequest>>());
//            }
//        }
//        public async Task<(HttpStatusCode StatusCode, Apiresponse<List<PersonaRequest>> result)> ObtenerListaPersonaCapturadas(int paginaActual, int cantidadRegistros)
//        {
//            try
//            {
             
//                return await CallGetAsync<Apiresponse<List<PersonaRequest>>>($"ObtenerPersonas?paginaActual={paginaActual}&cantidad={cantidadRegistros}");
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError, new Apiresponse<List<PersonaRequest>>());
//            }
//        }
//        public async Task<(HttpStatusCode StatusCode, string result)> ReporteCapturaPersona(Guid data)
//        {
//            try
//            {
//                return await CallPostAsync<Guid, string>("ReporteCaptura", data);
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError, "");
//            }
//        }

//        public async Task<(HttpStatusCode StatusCode, Apiresponse<List<EstadosResponse>> result)> ObtenerListaEstadosUnidos()
//        {
//            try
//            {
//                return await CallGetAsync<Apiresponse<List<EstadosResponse>>>("ObtenerEstadosUnidos");
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError, new Apiresponse<List<EstadosResponse>>());
//            }
//        }

//        public async Task<(HttpStatusCode StatusCode, Apiresponse<List<EstadosResponse>> result)> ObtenerListaMunicipiosChiapas()
//        {
//            try
//            {
//                return await CallGetAsync<Apiresponse<List<EstadosResponse>>>("ObtenerMunicipiosChiapas");
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError, new Apiresponse<List<EstadosResponse>>());
//            }
//        }

//        public async Task<(HttpStatusCode StatusCode, Apiresponse<List<EstadosResponse>> result)> ObtenerListaColoniasChiapas(string Nombre)
//        {
//            try
//            {
//                return await CallGetAsync<Apiresponse<List<EstadosResponse>>>($"ObtenerColoniasChiapas?Nombre={Nombre}");
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError, new Apiresponse<List<EstadosResponse>>());
//            }
//        }
//        public async Task<(HttpStatusCode StatusCode, Apiresponse<List<EstadosResponse>> result)> ObtenerOficios()
//        {
//            try
//            {
//                return await CallGetAsync<Apiresponse<List<EstadosResponse>>>($"ObtenerOficios");
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError, new Apiresponse<List<EstadosResponse>>());
//            }
//        }

//        public async Task<(HttpStatusCode StatusCode, Apiresponse<List<GeneroResponse>> result)> ObtenerDatosGenero()
//        {
//            try
//            {
//                return await CallGetAsync<Apiresponse<List<GeneroResponse>>>("ObtenerDatosGenero");
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError, new Apiresponse<List<GeneroResponse>>());
//            }
//        }
//        public async Task<(HttpStatusCode StatusCode, Apiresponse<List<OficioResponse>> result)> ObtenerDatosOficio(int idOficio)
//        {
//            try
//            {
//                return await CallGetAsync<Apiresponse<List<OficioResponse>>>($"ObtenerDatosOficio?idOficio={idOficio}");
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError, new Apiresponse<List<OficioResponse>>());
//            }
//        }
//        public async Task<(HttpStatusCode StatusCode, Apiresponse<List<ExtranjeroResponse>> result)> ObtenerEstadoExtranjero(int idEstadoExtranjero)
//        {
//            try
//            {
//                return await CallGetAsync<Apiresponse<List<ExtranjeroResponse>>>($"ObtenerEstadoExtranjero?IdEstadoExtranjero={idEstadoExtranjero}");
//            }
//            catch (Exception ex)
//            {
//                // Maneja la excepción y devuelve una respuesta válida
//                Console.Error.WriteLine($"Error al obtener datos: {ex.Message}");
//                return (HttpStatusCode.InternalServerError, new Apiresponse<List<ExtranjeroResponse>>());
//            }
//        }

//        public async Task<(HttpStatusCode StatusCode, Apiresponse<List<MenoresEdadResponse>> result)> ObtenerDatosMenoresEdad(int edadMin, int edadMax)
//        {
//            try
//            {
//                return await CallGetAsync<Apiresponse<List<MenoresEdadResponse>>>($"ObtenerDatosMenoresEdad?edadMin={edadMin}&edadMax={edadMax}");
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError, new Apiresponse<List<MenoresEdadResponse>>());
//            }
//        }

//        public async Task<(HttpStatusCode StatusCode, Apiresponse<List<GruposEdadResponse>> result)> ObtenerDatosGruposEdad()
//        {
//            try
//            {
//                return await CallGetAsync<Apiresponse<List<GruposEdadResponse>>>("ObtenerDatosGruposEdad");
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError, new Apiresponse<List<GruposEdadResponse>>());
//            }
//        }

//        public async Task<(HttpStatusCode StatusCode, SimpleResponse result)> AgregarUsuario(AgregarUsuarioRequest data)
//        {
//            try
//            {
//                return await CallPostAsync<AgregarUsuarioRequest, SimpleResponse>("AgregarUsuario", data);
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError, new SimpleResponse
//                {
//                    Mensaje = ex.Message,
//                    Exito = false
//                });
//            }
//        }

//        public async Task<(HttpStatusCode StatusCode, Apiresponse<List<ObtenerUsuarioResponse>> result)> ObtenerListaUsuarios()
//        {
//            try
//            {
//                return await CallGetAsync<Apiresponse<List<ObtenerUsuarioResponse>>>("ObtenerListaUsuarios");
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError, new Apiresponse<List<ObtenerUsuarioResponse>>());
//            }
//        }

//        public async Task<(HttpStatusCode StatusCode, SimpleResponse result)> EliminarUsuario(EliminarUsuarioRequest data)
//        {
//            try
//            {
//                return await CallPostAsync<EliminarUsuarioRequest, SimpleResponse>("EliminarUsuario", data);
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError, new SimpleResponse
//                {
//                    Mensaje = ex.Message,
//                    Exito = false
//                });
//            }
//        }

//        public async Task<(HttpStatusCode StatusCode, SimpleResponse result)> ActualizarUsuario(ActualizarUsuarioRequest data)
//        {
//            try
//            {
//                return await CallPostAsync<ActualizarUsuarioRequest, SimpleResponse>("ActualizarUsuario", data);
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError, new SimpleResponse
//                {
//                    Mensaje = ex.Message,
//                    Exito = false
//                });
//            }
//        }

//        public async Task<(HttpStatusCode StatusCode, string result)> Exportar()
//        {
//            try
//            {
//                return await CallGetAsync<string>("Exportar");
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError, string.Empty);
//            }
//        }

//        public async Task<(HttpStatusCode StatusCode, string Result)> ReporteExcel(int IdOficio)
//        {
//            try
//            {
//                return await CallGetAsync<string>($"GenerarExcel/{IdOficio}");
//            }
//            catch (Exception ex)
//            {
//                return (HttpStatusCode.InternalServerError, string.Empty);
//            }
//        }

      
//    }
//}
