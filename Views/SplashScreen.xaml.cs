using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace AutoService.Views
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        private readonly DispatcherTimer dT;

        public SplashScreen()
        {
            InitializeComponent();

            dT = new DispatcherTimer();
            dT.Tick += DTTick;
            dT.Interval = new TimeSpan(0, 0, 2);
            dT.Start();
        }

        private void DTTick(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            dT.Stop();
            Close();
        }

        private void GridMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
