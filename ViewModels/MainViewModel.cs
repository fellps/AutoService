using Reactive.Bindings;

namespace AutoService.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ReactiveCommand ExitCommand { get; set; }

        public void Exit()
        {
            App.Current.Shutdown();
        }

        public override void InitializeComponents()
        {
            ExitCommand = new ReactiveCommand();
            ExitCommand.Subscribe(Exit);
        }
    }
}
