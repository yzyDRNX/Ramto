//using Microsoft.AspNetCore.Components.Routing;
//using Microsoft.AspNetCore.Components;
//using Ramto.Lib.Helpers;
//using Ramto.Lib.Enumeraciones;
//using Ramto.Lib.OS.Interfaces;

//namespace Ramto.OS
//{
//    //public class NavigationService : INavigationService
//    {
//        string currentPage, previousPage;
//        internal NavigationManager NavigationManager { get; set; }
//        public Task GoBack()
//        {
//            if (!string.IsNullOrEmpty(previousPage))
//                NavigationManager.NavigateTo(previousPage);
//            return Task.CompletedTask;
//        }

//        public Task Home()
//        {
//            previousPage = string.Empty;
//            currentPage = "/";
//            NavigationManager.NavigateTo("/");
//            return Task.CompletedTask;
//        }

//        public Task NavigateTo(PagesKeys pageKey)
//        {
//            previousPage = currentPage;
//            currentPage = Routes.ObtenerRuta(pageKey);
//            NavigationManager.NavigateTo(currentPage);
//            return Task.CompletedTask;
//        }

//        public Task NavigateTo<T>(PagesKeys pageKey, T parametro)
//        {
//            throw new NotImplementedException();
//        }

//        public Task NavigateTo(PagesKeys pageKey, params object[] parametros)
//        {
//            string ParametroUrl = parametros[0].ToString();
//            previousPage = currentPage;
//            if (parametros.Length > 1 && parametros[1] != null)
//            {
//                currentPage = Routes.ObtenerRuta(pageKey, ParametroUrl, parametros[1].ToString());
//            }
//            else
//            {
//                currentPage = Routes.ObtenerRuta(pageKey, ParametroUrl);
//            }
//            NavigationManager.NavigateTo(currentPage);
//            return Task.CompletedTask;
//        }

//        public Task PushModal(ModalKeys popUpKey, params object[] parameter)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
