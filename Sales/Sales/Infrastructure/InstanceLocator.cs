
namespace Sales.Infrastructure
{
    using ViewModels;
    public class InstanceLocator
    {
        //clase principal
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }


    }
}
