using System;
using System.Collections.Generic;
using System.Text;

namespace Ramto.Modelos.Request
{
    public class ReporteCaptura
    {
        public int Folio { get; set; }
        public string Nombre { get; set; }
        public string TieneIdentificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string ClaveIdentificacion { get; set; }
        public string FotoIdentificacion { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public string FotoPerfil { get; set; }
        public byte[] FotoPerfilImage { get; set; }
        public string Telefono { get; set; }
        public string ViajaConFamiliares { get; set; }
        public string ViajaConMenores { get; set; }
        public string EstadoExtranjero { get; set; }
        public string LocalidadExtranjero { get; set; }
        public string MunicipioChiapas { get; set; }
        public string ColoniaChiapas { get; set; }
        public string Ocupacion { get; set; }
        public string AspiraAlgunEmpleo { get; set; }
        public string ExperienciaLaboral { get; set; }
        public DateTime FechaCaptura { get; set; }
        public string Capturista { get; set; }
        public string NombreFamiliar { get; set; }
        public string Parentesco { get; set; }
        public DateTime FechaNacimientoFamiliar { get; set; }
    }
}
