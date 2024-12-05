using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OrchardCore.DisplayManagement.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgerBJJ.Module.Controllers
{
    public class BadgerAdminController : Controller
    {
        //translating HTML content
        private readonly IHtmlLocalizer H;

        //system notifications and messages to users
        private readonly INotifier _notifier;

        //handles application logging
        private readonly ILogger _logger;

        //translating plain text strings
        public readonly IStringLocalizer T;

        public BadgerAdminController(
        IHtmlLocalizer<HomeController> htmlLocalizer, Notifier notifier,
        IStringLocalizer<HomeController> stringLocalizer,
        ILogger<HomeController> logger)
        {
            _notifier = notifier;
            _logger = logger;
            H = htmlLocalizer;
            T = stringLocalizer;
        }

        public ActionResult BadgerAdmin()
        {
            ViewData["Message"] = T["Wubbalubadubdub"];

            _notifier.SuccessAsync(H["Wubbalubadubdub"]);

            _logger.LogError("Some log about Wubbalubadubdub");

            return View();
        }
    }
}
