using Ramto.Lib.Enumeraciones;
using Ramto.Lib.Helpers;

namespace Ramto.Lib.OS.Interfaces
{
    public interface INavigationService
    {
        /// <summary>
        /// Regresa a la vista anterior
        /// </summary>
        /// <returns></returns>
        Task GoBack();
        /// <summary>
        /// Retorna a la vista que se ha definido como la vista princial
        /// </summary>
        /// <returns></returns>
        Task Home();
        /// <summary>
        /// Permite cambiar de vista sin envíar parametros a ésta
        /// </summary>
        /// <param name="pageKey"></param>
        /// <returns></returns>
        Task PushModal(ModalKeys popUpKey, params object[] parameter);
        /// <summary>
        /// PopUp con parametros
        /// </summary>
        /// <param name="pageKey"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task NavigateTo(PagesKeys pageKey);
        /// <summary>
        /// Permite cambiar de vista enviando un sólo parametro a la otra vista 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageKey"></param>
        /// <param name="parametro"></param>
        /// <returns></returns>
        Task NavigateTo<T>(PagesKeys pageKey, T parametro);
        /// <summary>
        /// Permite cambiar de vista enviando un arreglo de parametros de cualquier tipo
        /// </summary>
        /// <param name="pageKey"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        Task NavigateTo(PagesKeys pageKey, params object[] parametros);

    }
}
