using Ramto.Lib.ApiClient;
using Ramto.Modelos.Request;
using Ramto.Modelos.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramto.Lib.BL
{
    public class LoginBL
    {
        SeguridadApiClient seguridadApiClient = new SeguridadApiClient();

        public async Task<Apiresponse<UsuarioResponse>> IniciarSesion(UsuarioRequest data)
        {
            var response = await seguridadApiClient.IniciarSesion(data);
            return response.result;
        }
    }
}
