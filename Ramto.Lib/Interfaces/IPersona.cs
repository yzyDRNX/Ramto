
//using Ramto.Modelos.Custom;
//using Ramto.Modelos.Request;
//using Ramto.Modelos.Response;

//namespace SIIC.Migrantes.Lib.Interfaces
//{
//    public interface IPersona
//    {
//        Task<Apiresponse<List<EstadosResponse>>> ObtenerEstadosUnidos();
//        Task<Apiresponse<List<EstadosResponse>>> ObtenerMunicipiosChiapas();
//        Task<Apiresponse<List<EstadosResponse>>> ObtenerColoniasChiapas(string Municipio);
//        Task<Apiresponse<List<EstadosResponse>>> ObtenerOficios();
//        Task<Apiresponse<List<PersonaRequest>>> ObtenerListaPersonasCapturadas(int paginaActual, int cantidad);
//        Task<SimpleResponse> AgregarPersona(PersonaRequest persona);
//        Task<SimpleResponse> AgregarResidenciaPersona(ResidenciaPersonaRequest persona);
//        Task<SimpleResponse> AgregarFamiliar(FamiliarRequest persona);

//        Task<Apiresponse<List<FamiliarRequest>>> ObtenerListaFamiliar(Guid IdPersona);

//        Task<string> ReporteInformacionCapturada(Guid IdPersona);

//        Task<Apiresponse<List<GeneroResponse>>> ObtenerDatosGenero();
//        Task<Apiresponse<List<OficioResponse>>> ObtenerDatosOficio(int idOficio);
//        Task<Apiresponse<List<ExtranjeroResponse>>> ObtenerEstadoExtranjero(int idEstadoExtranjero);
//        Task<Apiresponse<List<MenoresEdadResponse>>> ObtenerDatosMenoresEdad(int edadMin, int edadMax);
//        Task<Apiresponse<List<GruposEdadResponse>>> ObtenerDatosGruposEdad();
//        Task<SimpleResponse> AgregarUsuario(AgregarUsuarioRequest usuario);
//        Task<Apiresponse<List<ObtenerUsuarioResponse>>> ObtenerListaUsuarios();
//        Task<SimpleResponse> EliminarUsuario(EliminarUsuarioRequest usuario);
//        Task<SimpleResponse> ActualizarUsuario(ActualizarUsuarioRequest usuario);
//        Task<string> Exportar();

//        //Task<string> GenerarExcel();
//    }
//}
