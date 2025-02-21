namespace Ramto.Modelos.Request
{
    public class PersonaRequest
    {
        public Guid IdPersona { get; set; }
        public int IdCapturo { get; set; }
        public int Folio { get; set; }
        public DateTime FechaCaptura { get; set; }
        public string Capturista { get; set; }
        public string LugarCaputura { get; set; }
        public string Nombre { get; set; }= "";
        public string ApellidoPaterno { get; set; } = "";
        public string ApellidoMaterno { get; set; } ="";
        public bool TieneIdentificacion { get; set; } = false;
        public byte Genero { get; set; }= 0;
        public DateTime FechaNacimiento { get; set; }=DateTime.Now;
        public string CorreoElectronico { get; set; } = "";
        public string FotoPerfil { get; set; } = "";
        public string Identificacion { get; set; } = "";
        public string FotoIdentificacion { get; set; } = "";
        public string FotoIdentificacionReverso { get; set; } = "";
        public string ClaveIdentificacion { get; set; } = "";
        public string Telefono { get; set; } = "";
        public int CantidadRegistros { get; set; } 
        public int TotalRegistros { get; set; }

    }
}
