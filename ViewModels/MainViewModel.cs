using AutoService.Business;
using Prism.Mvvm;
using Reactive.Bindings;

namespace AutoService.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public ReactiveCommand ExitCommand { get; set; }

        public MainViewModel(MainBusiness mainBusiness)
        {
            ExitCommand = new ReactiveCommand();
            ExitCommand.Subscribe(mainBusiness.Exit);
        }
    }
}
