
using Ramto.Lib.OS;
using Ramto.Modelos.Request;
using Ramto.Modelos.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Ramto.Lib.ApiClient
{
    public class SeguridadApiClient:WebApiClient
    {
        public SeguridadApiClient() : base(SettingsValuesClient.CurrentApiValues.UrlWebApi, "Seguridad")
        {

        }
        #region Métodos
        public async Task<(HttpStatusCode StatusCode, Apiresponse<UsuarioResponse> result)> IniciarSesion(UsuarioRequest loginRequest)
        {
            try
            {
                return await CallPostAsync<UsuarioRequest,Apiresponse<UsuarioResponse>>("IniciarSesion", loginRequest);
            }
            catch (Exception ex)
            {
                return (HttpStatusCode.InternalServerError, new Apiresponse<UsuarioResponse>
                {
                    // Puedes personalizar el mensaje de error según tus necesidades
                    Mensaje = ex.Message,
                    Exito = false,
                    data = null  // Puedes devolver una lista vacía o null
                });
            }
        }
      
        #endregion
    }
}
