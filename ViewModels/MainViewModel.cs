using Reactive.Bindings;

namespace AutoService.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ReactiveCommand ExitCommand { get; private set; }

        public MainViewModel()
        {
            ExitCommand = new ReactiveCommand();
            ExitCommand.Subscribe(Exit);
        }

        public void Exit()
        {
            App.Current.Shutdown();
        }
    }
}
