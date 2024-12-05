using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OrchardCore.DisplayManagement.Notify;
//using OrchardCore.Notifications;

namespace BadgerBJJ.Module.Controllers
{

    //[Area("BadgerBJJ.Module")]
    public class HomeController : Controller
    {
        //translating HTML content
        private readonly IHtmlLocalizer H;

        //system notifications and messages to users
        private readonly INotifier _notifier;

        //handles application logging
        private readonly ILogger _logger;

        //translating plain text strings
        public readonly IStringLocalizer T;

        public HomeController(
        IHtmlLocalizer<HomeController> htmlLocalizer, Notifier notifier,
        IStringLocalizer<HomeController> stringLocalizer,
        ILogger<HomeController> logger)
        {
            H = htmlLocalizer;
            _notifier = notifier;
            T = stringLocalizer;
            _logger = logger;
        }

        //controller action methods
        public ActionResult Index()
        {
            ViewData["Message"] = T["Wubbalubadubdub"];

            _notifier.SuccessAsync(H["Wubbalubadubdub"]);

            _logger.LogError("Some log about Wubbalubadubdub");

            return View();

            //var model = new MyViewModel();
            //return View(model);
        }


        //[HttpGet, Route("Home/NotifyUser")]
        //public async Task<IActionResult> NotifyUser()
        //{

        //    LoggerVar.LogError("The user has been notified about some error!");

        //    await NotifierVar.InformationAsync(H["You have been notified"]);

        //    return View();

        //}
    }
}
