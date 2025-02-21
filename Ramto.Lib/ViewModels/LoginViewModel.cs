using Core.MVVM;
using Ramto.Lib.BL;
using Ramto.Lib.Enumeraciones;
using Ramto.Lib.OS.Interfaces;
using Ramto.Modelos.Request;
using Ramto.Modelos.Response;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ramto.Lib.ViewModels
{
   
    public class LoginViewModel: ViewModelBase
    {
        private List<string> errores = new List<string>();
        public List<string> Errores { get => errores; set => Set(ref errores, value); }

        #region Propiedades
        private UsuarioRequest usuarioRequest = new UsuarioRequest();
        public UsuarioRequest UsuarioRequest { get => usuarioRequest; set => Set(ref usuarioRequest, value); }

        private UsuarioResponse usuarioResponse = new UsuarioResponse();
        public UsuarioResponse UsuarioResponse { get => usuarioResponse; set => Set(ref usuarioResponse, value); }

        readonly LoginBL loginBL;
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            loginBL = new LoginBL();
        }
        #endregion

        #region Comandos
        RelayCommand iniciarSesionCommand = null;
        public RelayCommand IniciarSesionCommand
        {
            get => iniciarSesionCommand ??= new RelayCommand(async () =>
            {
                try
                {
                    //await DependencyService.Get<IModalesService>().AlertPopUp(ModalKeys.Cargando);
                    if (!ValidarCamposL())
                    {
                      //  await DependencyService.Get<IModalesService>().PushErrorModal("Es necesario las credenciales para ingresar");

                    }
                    else
                    {
                        Loading = true;
                        var resultado = await loginBL.IniciarSesion(UsuarioRequest);
                        Loading = false;

                        if (resultado.Exito)
                        {
                            UsuarioResponse = resultado.data; // Asigna el resultado a UsuarioResponse

                           
                                await DependencyService.Get<IAutenticacionService>().Login(resultado.data);
                                await DependencyService.Get<ILocalStorage>().SetValue(LocalStorageKeys.Usuario, resultado.data);
                                await DependencyService.Get<INavigationService>().NavigateTo(Helpers.PagesKeys.Dashboard);
                  
                        }
                        else
                        {
                            Errores.Add("Usuario y/o contraseña incorrecta, verifique por favor.");
                        }



                    }


                }
                catch (Exception ex)
                {


                }
                finally
                {
                    //await DependencyService.Get<IModalesService>().PopModal();
                    Loading = false;
                }




            }, () => { return true; });
        }
        #endregion
        #region Metodos
  public bool ValidarCamposL()
        {
            Errores.Clear();
            bool resultado = true;


            if (string.IsNullOrWhiteSpace(UsuarioRequest.Username) || string.IsNullOrWhiteSpace(UsuarioRequest.Password))
            {
                Errores.Add("Usuario o contraseña vacías." + 
                    " Es necesario usar las credenciales para ingresar");
                resultado = false;

            }


    
            return resultado;


        }
        #endregion
      
    }
}
