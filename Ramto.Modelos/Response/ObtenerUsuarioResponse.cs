using System;
using System.Collections.Generic;
using System.Text;

namespace Ramto.Modelos.Response
{
    public class ObtenerUsuarioResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public int IdRol { get; set; }
        public string Password { get; set; }
    }
}