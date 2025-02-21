//using Microsoft.JSInterop;
//using Ramto.Lib.Enumeraciones;
//using Ramto.Lib.OS.Interfaces;
//using System.Text.Json;

//namespace Ramto.OS
//{
//    public class LocalStorage : ILocalStorage
//    {
//        internal IJSRuntime LocalService { get; set; }
//        public async Task ClearAll()
//        {
//            await LocalService.InvokeVoidAsync("sessionStorage.clear").ConfigureAwait(false);
//        }

//        public async Task<string> GetToken()
//        {
//            return await LocalService.InvokeAsync<string>("sessionStorage.getItem", "Token").ConfigureAwait(false);
//        }

//        public async Task<T> GetValue<T>(LocalStorageKeys key)
//        {
//            var data = await LocalService.InvokeAsync<string>("sessionStorage.getItem", key.ToString()).ConfigureAwait(false);
//            if (data == null)
//                return default;
//            return JsonSerializer.Deserialize<T>(data);
//        }

//        public async Task RemoveItem(LocalStorageKeys key)
//        {
//            await LocalService.InvokeVoidAsync("sessionStorage.removeItem", key.ToString()).ConfigureAwait(false);
//        }

//        public async Task RemoveToken()
//        {
//            await LocalService.InvokeVoidAsync("sessionStorage.removeItem", "Token").ConfigureAwait(false);
//        }

//        public async Task SetToken(string token)
//        {
//            await LocalService.InvokeVoidAsync("sessionStorage.setItem", "Token", token).ConfigureAwait(false);
//        }

//        public async Task SetValue<T>(LocalStorageKeys key, T value)
//        {
//            await LocalService.InvokeVoidAsync("sessionStorage.setItem", key.ToString(), JsonSerializer.Serialize(value)).ConfigureAwait(false);
//        }
//    }
//}
