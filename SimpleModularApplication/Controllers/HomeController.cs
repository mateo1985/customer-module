namespace SimpleModularApplication.Controllers
{
    using System.Linq;
    using Core.Common;
    using Microsoft.AspNetCore.Mvc;
    using SimpleModularApplication.ViewModels;

    public class HomeController : Controller
    {
        private IModuleService modulService;

        public HomeController(IModuleService moduleService)
        {
            this.modulService = moduleService;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel(this.modulService.Modules.Select(x => x.Value.ModuleName).ToList());
            return View(homeViewModel);
        }
    }
}