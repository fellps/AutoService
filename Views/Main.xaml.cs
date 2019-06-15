using Prism.Ioc;
using Prism.Regions;
using System.Windows;
using Unity.Attributes;

namespace AutoService.Views
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        [Dependency]
        public IContainerExtension ContainerExtension { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public Main()
        {
            InitializeComponent();
        }

        public void OnLoaded(object sender, RoutedEventArgs e)
        {
            RegionManager.AddToRegion("MainRegion", ContainerExtension.Resolve<Home>());
        }
    }
}
