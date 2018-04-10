namespace SimpleModularApplication.ViewModels
{
    using System.Collections.Generic;

    public class HomeViewModel
    {
        private IList<string> modules;

        public HomeViewModel(IList<string> modules)
        {
            this.modules = modules;
        }

        public IList<string> Modules
        {
            get
            {
                return this.modules; 
            }
        }
    }
}
