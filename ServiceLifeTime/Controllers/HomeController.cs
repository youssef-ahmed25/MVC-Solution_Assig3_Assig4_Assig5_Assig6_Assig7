using Microsoft.AspNetCore.Mvc;
using ServiceLifeTime.Models;
using ServiceLifeTime.Services;
using System.Diagnostics;
using System.Text;

namespace ServiceLifeTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScopedService scopedService1;
        private readonly IScopedService scopedService2;
        private readonly ISingletonService singletonService1;
        private readonly ISingletonService singletonService2;
        private readonly ITransientService transientService1;
        private readonly ITransientService transientService2;

        public HomeController(IScopedService scopedService1,
                              IScopedService scopedService2,
                              ISingletonService singletonService1,
                              ISingletonService singletonService2,
                              ITransientService transientService1,
                              ITransientService transientService2)
        {
            this.scopedService1 = scopedService1;
            this.scopedService2 = scopedService2;
            this.singletonService1 = singletonService1;
            this.singletonService2 = singletonService2;
            this.transientService1 = transientService1;
            this.transientService2 = transientService2;
        }

        public string Index()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"scopedService1: {scopedService1.GetGuid()}");
            sb.AppendLine($"scopedService2: {scopedService2.GetGuid()}");
            sb.AppendLine($"transientService1: {transientService1.GetGuid()}");
            sb.AppendLine($"transientService2: {transientService2.GetGuid()}");
            sb.AppendLine($"singletonService1: {singletonService1.GetGuid()}");
            sb.AppendLine($"singletonService2: {singletonService2.GetGuid()}");

            return sb.ToString();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
