using Microsoft.AspNetCore.Components;
using Ramto.Lib.Locator;
using Ramto.Lib.ViewModels;
using Microsoft.JSInterop;

namespace Ramto.Pages
{
    public partial class Login
    {
        [Inject]
        private IJSRuntime JS { get; set; }

        public LoginViewModel viewModel = Locator.GetViewModel<LoginViewModel>();

    }
}
