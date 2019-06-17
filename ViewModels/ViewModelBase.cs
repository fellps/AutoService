using MaterialDesignThemes.Wpf;
using Prism.Mvvm;
using System;

namespace AutoService.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        public SnackbarMessageQueue CustomSnackBarMessageQueue { get; private set; }

        public ViewModelBase()
        {
            CustomSnackBarMessageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(1500));
        }

        public void SnackBarMessage(string message, string action = "OK", Action handler = null)
        {
            CustomSnackBarMessageQueue.Enqueue(message, action, handler ?? (() => { }));
        }
    }
}
