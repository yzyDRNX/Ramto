using Ramto.Lib.Enumeraciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramto.Lib.OS.Interfaces
{
    interface IModalesService
    {
        /// <summary>
        /// Desapila todos los modales que se encuentren actualmente en la pantalla
        /// </summary>
        /// <returns></returns>
        Task PopToRootModal();
        /// <summary>
        /// Desapila el ultimo modal que se encuentra en la vista y en la pila
        /// </summary>
        /// <returns></returns>
        Task PopModal();
        /// <summary>
        /// Pone en pantalla un modal que no recibe algún parámetro
        /// </summary>
        /// <param name="popUpKey"></param>
        /// <returns></returns>
        Task PushModal(ModalKeys modalKeys);
        /// <summary>
        /// Apila en pantalla un modal que recibirá un parámetro de tipo específico
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="popUpKey"></param>
        /// <param name="parametro"></param>
        /// <returns></returns>
        Task PushModal<T>(ModalKeys modalKeys, T parametro);
        /// <summary>
        /// Apila en pantalla un modal que recibirá diferentes parámetros de distintos tipos de valor
        /// </summary>
        /// <param name="popUpKey"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        Task PushModal(ModalKeys modalKeys, params object[] parametros);
        /// <summary>
        /// Muestra en pantalla un modal que retornaraá un valor boleano como respuesta al cerrarse
        /// </summary>
        /// <param name="popUpKey"></param>
        /// <returns></returns>
        Task<bool> PushReturningDataModal(ModalKeys modalKeys);
        /// <summary>
        /// Muestra en pantalla un modal que que recibirá un parámetro de tipo específico y que al cerrarse retormará una variable booleana
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="popUpKey"></param>
        /// <param name="parametro"></param>
        /// <returns></returns>
        Task<bool> PushReturningDataModal<T>(ModalKeys modalKeys, T parametro);
        /// <summary>
        /// Muestra en pantalla un modal que recibirá diferentes parámetros de distintos tipos y que al cerrarse retornará una variable booleada
        /// </summary>
        /// <param name="popUpKey"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<bool> PushReturningDataModal(ModalKeys modalKeys, params object[] param);
        /// <summary>
        /// Pone en pantalla un modal de advertencia que puede ser personalizado
        /// </summary>
        /// <returns></returns>
        Task<bool> PushAdverteciaModal(string mensajeAdicional, string encadezado = "¡Advertencia!", string mensajeSi = "Sí", string mensajeNo = "No");
        /// <summary>
        /// Pone en pantalla un modal de error que puede ser personalizado
        /// </summary>
        /// <param name="mensajeAdicional"></param>
        /// <param name="encadezado"></param>
        /// <param name="mensajeAceptar"></param>
        /// <returns></returns>
        Task PushErrorModal(string mensajeAdicional, string encadezado = "¡Error!", string mensajeAceptar = "Aceptar");

        Task PushAceptarModalAutoHide(string mensajeAdicional, double time = 2, string encadezado = "¡Éxito!");

        Task AlertPopUp(ModalKeys modalKeys);
    }
}
