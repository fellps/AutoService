namespace AutoService.Business
{
    public abstract class Business
    {
        protected Business()
        {
            InitializeComponents();
        }

        public abstract void InitializeComponents();
    }
}
