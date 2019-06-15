namespace AutoService.Business
{
    public class MainBusiness : Business
    {
        public MainBusiness()
        {
        }

        public override void InitializeComponents()
        {
        }

        internal void Exit()
        {
            App.Current.Shutdown();
        }
    }
}
