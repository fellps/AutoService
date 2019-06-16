using AutoService.Business;
using AutoService.Models;
using Prism.Mvvm;
using Reactive.Bindings;

namespace AutoService.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        public ReactiveCommand SaveCommand { get; set; }
        public ReadOnlyReactiveCollection<MotorizedCardReaderModel> MotorizedCardReaderCollection { set; get; }
        public ReactiveProperty<string> Text { get; set; }
        public ReactiveProperty<MotorizedCardReaderModel> SelectedMotorizedCardReader { set;  get; }

        public HomeViewModel(HomeBusiness homeBusiness)
        {
            Text = homeBusiness.Text;
            MotorizedCardReaderCollection = homeBusiness.MotorizedCardReaderCollection;
            SelectedMotorizedCardReader = homeBusiness.SelectedMotorizedCardReader;

            SaveCommand = new ReactiveCommand();
            SaveCommand.Subscribe(homeBusiness.Save);
        }
    }
}
