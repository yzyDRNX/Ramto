using Ramto.Lib.Enumeraciones;

namespace Ramto.Lib.OS.Interfaces
{
    public interface ILocalStorage
    {
        /// <summary>
        /// Recupera un dato guardado en el nevagador con base al ValueKey pasado como paametro
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        ///Task<T> GetItem<T>(string key)
        Task<T> GetValue<T>(LocalStorageKeys key);

        /// <summary>
        /// Define un valor en navegador con base al ValueKey pasado como parametro
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        ///  Task SetItem<T>(string key, T value);
        Task SetValue<T>(LocalStorageKeys key, T value);

        /// <summary>
        /// Remueve un valor en específico 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task RemoveItem(LocalStorageKeys key);

        /// <summary>
        /// Recuperar el Token que se encuentra almacenado en el navegador
        /// </summary>
        /// <returns></returns>
        Task<string> GetToken();

        /// <summary>
        ///  Obtiene el token que se encuentra registrado en el navegador
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Task SetToken(string value);

        /// <summary>
        /// Elimina de memoria el Token que se ha almacenado con antelación
        /// </summary>
        /// <returns></returns>
        Task RemoveToken();
        /// <summary>
        /// Elimina todo lo que haya en memoria de sesión
        /// </summary>
        /// <returns></returns>
        Task ClearAll();
    }
}
