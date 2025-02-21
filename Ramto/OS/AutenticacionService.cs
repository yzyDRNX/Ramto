//using Core.MVVM;
//using Ramto.Lib.Enumeraciones;
//using Ramto.Lib.OS.Interfaces;
//using Ramto.Modelos.Response;

//namespace Ramto.OS
//{
//    public class AutenticacionService : IAutenticacionService
//    {

//        /// <summary>
//        /// Instancia del usuario actual que usa el sistema
//        /// </summary>
//        private UsuarioResponse usuario;
//        /// <summary>
//        /// Variable bandera para saber si un usuario está Logueado o no
//        /// </summary>
//        private bool InicioSesion;

//        private List<UsuarioResponse> Permisos;
//        public async Task Inicializar()
//        {
//            this.usuario = await DependencyService.Get<ILocalStorage>().GetValue<UsuarioResponse>(LocalStorageKeys.Usuario);
//            this.InicioSesion = this.usuario == null ? false : true;
//        }

//        public bool IsLogued()
//        {
//            return this.InicioSesion;
//        }

//        public Task Login(UsuarioResponse usuario)
//        {
//            this.usuario = usuario;
//            this.InicioSesion = true;
//            return Task.CompletedTask;
//        }

//        public Task LogOut()
//        {
//            this.usuario = null;
//            this.InicioSesion = false;
//            return Task.CompletedTask;
//        }

//        public UsuarioResponse ObtenerUsuario()
//        {
//            return this.usuario;
//        }

//        public async Task<List<UsuarioResponse>> ObtenerPermisos()
//        {
//            this.Permisos = await DependencyService.Get<ILocalStorage>().GetValue<List<UsuarioResponse>>(LocalStorageKeys.Permisos);
//            return this.Permisos;
//        }
//    }
//}
