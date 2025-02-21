using System;
using System.Collections.Generic;
using System.Text;

namespace Ramto.Lib.Locator
{
    public class Locator
    {
        private static Dictionary<object, object> servicecontainer = new Dictionary<object, object>();
        /// <summary>
        /// Receibe una tipo de clase como parametro. Si ya se encuentra registrado el ViewModel lo retorna,
        /// En caso contrario lo crea y lo retorna
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetViewModel<T>() where T : new()
        {
            try
            {
                if (!servicecontainer.ContainsKey(typeof(T)))
                {
                    servicecontainer.Add(typeof(T), new T());
                }
                return (T)servicecontainer[typeof(T)];
            }
            catch (Exception)
            {
                throw new NotImplementedException("Error obteniendo ViewModel");
            }
        }

        public static void DestoyViewModel<T>()
        {
            try
            {
                if (servicecontainer.ContainsKey(typeof(T)))
                {
                    servicecontainer.Remove(typeof(T));
                }
            }
            catch (Exception)
            {
                throw new NotImplementedException("Error al eliminar ViewModel");
            }
        }
    }
}
