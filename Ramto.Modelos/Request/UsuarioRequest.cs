using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Ramto.Modelos.Request
{
    public class UsuarioRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
