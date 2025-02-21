using Ramto.Modelos.Request;
using Ramto.Modelos.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramto.Lib.Interfaces
{
    public interface ISeguridad
    {
        Task<Apiresponse<UsuarioResponse>> Login(UsuarioRequest usuario);
    }
}
