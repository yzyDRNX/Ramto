//using Ramto.Lib.ApiClient;
//using Ramto.Modelos.Custom;
//using Ramto.Modelos.Request;
//using Ramto.Modelos.Response;
//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Text;

//namespace Ramto.Lib.BL
//{
//    public class PersonaBL
//    {
//        PersonaApiClient personaApiClient = new PersonaApiClient();


//        #region Catalogos
//        public async Task<List<EstadosResponse>> ObtenerListaEstadosUnidos()
//        {
//            List<EstadosResponse> Lista = new List<EstadosResponse>();
//            var response = await personaApiClient.ObtenerListaEstadosUnidos();  
//            return response.result.data;
//        }
//        public async Task<List<EstadosResponse>> ObtenerListaMunicipiosChiapas()
//        {
//            List<EstadosResponse> Lista = new List<EstadosResponse>();
//            var response = await personaApiClient.ObtenerListaMunicipiosChiapas();
//            return response.result.data;
//        }
//        public async Task<List<EstadosResponse>> ObtenerListaColoniasChiapas(string Nombre)
//        {
//            List<EstadosResponse> Lista = new List<EstadosResponse>();
//            var response = await personaApiClient.ObtenerListaColoniasChiapas(Nombre);
//            return response.result.data;
//        }
//        public async Task<List<EstadosResponse>> ObtenerOficios()
//        {
//            List<EstadosResponse> Lista = new List<EstadosResponse>();
//            var response = await personaApiClient.ObtenerOficios();
//            return response.result.data;
//        }
//        #endregion
//        public async Task<SimpleResponse> AgregarPersona(PersonaRequest data)
//        {
//            var response = await personaApiClient.AgregarPersona(data);
//            return response.result;
//        }

//        public async Task<SimpleResponse> AgregarResidenciaPersona(ResidenciaPersonaRequest data)
//        {
//            var response = await personaApiClient.AgregarResidenciaPersona(data);
//            return response.result;
//        }
//        public async Task<SimpleResponse> AgregarFamiliarPersona(FamiliarRequest data)
//        {
//            var response = await personaApiClient.AgregarFamiliarPersona(data);
//            return response.result;
//        }

//        public async Task<List<FamiliarRequestDTO>> ObtenerListaFamiliarPersona(FamiliarRequest data)
//        {
//            List<FamiliarRequestDTO> Lista = new List<FamiliarRequestDTO>();
//            var response = await personaApiClient.ObtenerListaFamiliarPersona(data);

//            foreach (var item in response.result.data)
//            {
//                Lista.Add(new FamiliarRequestDTO()
//                {                
//                    IdPersona = item.IdPersona,
//                    Nombre = item.Nombre,  
//                    Apellidos=item.Apellidos,
//                    Parentesco = item.Parentesco.ToString(),
//                    FechaNacimiento = item.FechaNacimiento,


//                });
//            }

//            return Lista;
//        }
//        public async Task<List<PersonaRequestDTO>> ObtenerListaPersonasCapturadas(int paginaActual, int cantidadRegistros)
//        {
//            List<PersonaRequestDTO> Lista = new List<PersonaRequestDTO>();
//            var response = await personaApiClient.ObtenerListaPersonaCapturadas(paginaActual, cantidadRegistros);

//            foreach (var item in response.result.data)
//            {
//                Lista.Add(new PersonaRequestDTO()
//                {
//                    IdPersona = item.IdPersona,
//                    Folio = item.Folio,
//                    Nombre = item.Nombre,
//                    FechaNacimiento = item.FechaNacimiento,
//                    FechaCaptura = item.FechaCaptura,
//                    Capturista = item.Capturista,
//                });
//            }

//            return Lista;
//        }
//        public async Task<string> ReporteCapturaPersona(Guid data)
//        {
           
//            var response = await personaApiClient.ReporteCapturaPersona(data);       

//            return response.result;
//        }

//        public async Task<List<GeneroResponse>> ObtenerGenerosGrafica()
//        {
//            var response = await personaApiClient.ObtenerDatosGenero();
//            return response.result.data;
//        }


//        public async Task<List<MenoresEdadResponse>> ObtenerMenoresGrafica(int edadMin, int edadMax)
//        {
//            var response = await personaApiClient.ObtenerDatosMenoresEdad(edadMin, edadMax);
//            if (response.StatusCode == HttpStatusCode.OK)
//            {
//                return response.result.data;
//            }
//            else
//            {
//                Console.Error.WriteLine($"Error al obtener datos de menores de edad: {response.StatusCode}");
//                return new List<MenoresEdadResponse>();
//            }
//        }


//        public async Task<List<GruposEdadResponse>> ObtenerGruposEdadGrafica()
//        {
//            var response = await personaApiClient.ObtenerDatosGruposEdad();
//            return response.result.data;
//        }

//        public async Task<List<ExtranjeroResponse>> ObtenerExtranjeroGrafica(int idEstadoExtranjero)
//        {
//            var response = await personaApiClient.ObtenerEstadoExtranjero(idEstadoExtranjero);
//            return response.result.data;
//        }

//        public async Task<List<OficioResponse>> ObtenerOficiosGrafica(int idOficio)
//        {
//            var response = await personaApiClient.ObtenerDatosOficio(idOficio);
//            return response.result.data;
//        }

      
//        public async Task<SimpleResponse> AgregarUsuario(AgregarUsuarioRequest data)
//        {
//            var response = await personaApiClient.AgregarUsuario(data);
//            return response.result;
//        }

//        public async Task<List<ObtenerUsuarioResponse>> ObtenerListaUsuarios()
//        {
//            var response = await personaApiClient.ObtenerListaUsuarios();
//            return response.result.data;
//        }

//        public async Task<SimpleResponse> EliminarUsuario(EliminarUsuarioRequest data)
//        {
//            var response = await personaApiClient.EliminarUsuario(data);
//            return response.result;
//        }

//        public async Task<SimpleResponse> ActualizarUsuario(ActualizarUsuarioRequest data)
//        {
//            var response = await personaApiClient.ActualizarUsuario(data);
//            return response.result;
//        }

//        public async Task<string> Exportar()
//        {
//            var response = await personaApiClient.Exportar();
//            return response.result;
//        }

       
//        public async Task<string> ReporteExcel(int IdOficio)
//        {
//            var response = await personaApiClient.ReporteExcel(IdOficio);
//            return response.Result;
//        }

 

//    }
//}
