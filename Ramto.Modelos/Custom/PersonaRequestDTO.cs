using Core.MVVM;

namespace Ramto.Modelos.Custom
{
    public class PersonaRequestDTO: ObservableObject
    {
        private Guid idPersona;
        public Guid IdPersona { get => idPersona; set => Set(ref idPersona, value); }
        private int folio ;
        public int Folio { get => folio; set => Set(ref folio, value); }
        private string capturista;
        public string Capturista { get => capturista; set => Set(ref capturista, value); }
        private DateTime fechaCaptura;
        public DateTime FechaCaptura { get => fechaCaptura; set => Set(ref fechaCaptura, value); }

        private string nombre;
        public string Nombre { get => nombre; set => Set(ref nombre, value); }

        private string apellidoPaterno;
        public string ApellidoPaterno { get => apellidoPaterno; set => Set(ref apellidoPaterno, value); }

        private string apellidoMaterno;
        public string ApellidoMaterno { get => apellidoMaterno; set => Set(ref apellidoMaterno, value); }

        private bool tieneIdentificacion;
        public bool TieneIdentificacion { get => tieneIdentificacion; set => Set(ref tieneIdentificacion, value); }

        private string fotoIdentificacion;
        public string FotoIdentificacion { get => fotoIdentificacion; set => Set(ref fotoIdentificacion, value); }

        private string fotoIdentificacionReverso;
        public string FotoIdentificacionReverso { get => fotoIdentificacionReverso; set => Set(ref fotoIdentificacionReverso, value); }

        private string claveIdentificacion;
        public string ClaveIdentificacion { get => claveIdentificacion; set => Set(ref claveIdentificacion, value); }
        private byte genero;
        public byte Genero { get => genero; set => Set(ref genero, value); }

        private DateTime fechaNacimiento = DateTime.Now;
        public DateTime FechaNacimiento { get => fechaNacimiento; set => Set(ref fechaNacimiento, value); }

        private string correoElectronico;
        public string CorreoElectronico { get => correoElectronico; set => Set(ref correoElectronico, value); }
        private string telefono;
        public string Telefono { get => telefono; set => Set(ref telefono, value); }

        private string fotoPerfil="";
        public string FotoPerfil { get => fotoPerfil; set => Set(ref fotoPerfil, value); }

        private string identificacion;
        public string Identificacion { get => identificacion; set => Set(ref identificacion, value); }

        private bool viajaConFamiliares;
        public bool ViajaConFamiliares { get => viajaConFamiliares; set => Set(ref viajaConFamiliares, value); }
        private bool viajaConMenores;
        public bool ViajaConMenores { get => viajaConMenores; set => Set(ref viajaConMenores, value); }

        private byte lugarDestino;
        public byte LugarDetino { get => lugarDestino; set => Set(ref lugarDestino, value); }

        private string estado;
        public string Estado { get => estado; set => Set(ref estado, value); }

        private string lugarOrigen;
        public string LugarOrigen { get => lugarOrigen; set => Set(ref lugarOrigen, value); }

        private string ocupacion;
        public string Ocupacion { get => ocupacion; set => Set(ref ocupacion, value); }

        private bool aspiraAlgunEmpleo;
        public bool AspiraAlgunEmpleo { get => aspiraAlgunEmpleo; set => Set(ref aspiraAlgunEmpleo, value); }

        private string experienciaLaboral;
        public string ExperienciaLaboral { get => experienciaLaboral; set => Set(ref experienciaLaboral, value); }
        private int idCapturo;
        public int IdCapturo { get => idCapturo; set => Set(ref idCapturo, value); }

        private int totalRegistros;
        public int TotalRegistros { get => totalRegistros; set => Set(ref totalRegistros, value); }
    }
}
