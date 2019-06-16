using Prism.Mvvm;

namespace AutoService.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        public ViewModelBase()
        {
            InitializeComponents();
        }

        public abstract void InitializeComponents();
    }
}
