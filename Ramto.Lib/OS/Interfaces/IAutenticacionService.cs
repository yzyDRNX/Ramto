using Ramto.Modelos.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramto.Lib.OS.Interfaces
{
    public interface IAutenticacionService
    {  /// <summary>
       /// Inicializa la instancia de del objeto Usuario recuperado del almacenamiento local
       /// </summary>
       /// <returns></returns>
        Task Inicializar();

        /// <summary>
        /// Recupera la instancia del objeto usuario
        /// </summary>
        /// <returns></returns>
        UsuarioResponse ObtenerUsuario();

        /// <summary>
        /// Establece el valor de la instancia privada de la clase usuario con el valor recibido por el API
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        Task Login(UsuarioResponse usuario);

        /// <summary>
        /// Destruye la instancia actual del objeto usuario 
        /// </summary>
        /// <returns></returns>
        Task LogOut();

        /// <summary>
        /// Retorna un valor booleano que espeicifca si el usuario ha iniciado sesión o no 
        /// </summary>
        /// <returns></returns>
        bool IsLogued();

        //Task<List<SacPermisosUsuariosDTO>> ObtenerPermisos();

    }
}
