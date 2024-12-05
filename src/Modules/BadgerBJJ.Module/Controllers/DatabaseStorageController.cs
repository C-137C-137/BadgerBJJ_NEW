using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BadgerBJJ.Module.Models;
using YesSql;


namespace BadgerBJJ.Module.Controllers
{
    public class DatabaseStorageController : Controller
    {
        //user notifications and system messages
        private readonly INotifier NotifierVar;

        //database operations and transactions, handles CRUD
        private readonly YesSql.ISession SessionVar;

        //display of ScheduleModel objects
        private readonly IDisplayManager<ScheduleModel> ScheduleDisplayManager;

        //ranslating HTML content
        private readonly IHtmlLocalizer H;

        //access to model updating functionality
        private readonly IUpdateModelAccessor UpdateModelAccessor;



        public DatabaseStorageController(
        YesSql.ISession session,
        IDisplayManager<ScheduleModel> scheduleDisplayManager,
        INotifier notifier,
        IHtmlLocalizer<DatabaseStorageController> htmlLocalizer,
        IUpdateModelAccessor updateModelAccessor)
        {
            this.NotifierVar = notifier;
            this.SessionVar = session;
            this.ScheduleDisplayManager = scheduleDisplayManager;
            this.H = htmlLocalizer;
                
        }

        //[HttpGet]
        //public IActionResult Register4Class() => View();

        //ValidateAntiForgeryToken --> prevents Cross-Site Request Forgery
        //controller action method --> Register4Class view
        [HttpPost, ActionName(nameof(Register4Class)), ValidateAntiForgeryToken]
        public async Task<IActionResult> Register4Class()
        {

            foreach (var bjjclass in CreateDemoSchedule())
            {
                //items are saved to db
                await SessionVar.SaveAsync(bjjclass);
            }

            await NotifierVar.InformationAsync(H["Demo schedule has been created in the database."]);

            return RedirectToAction(nameof(Register4Class));
        }

        private static ScheduleModel[] CreateDemoSchedule()
        {
            ScheduleModel schedule1 = new ScheduleModel();
            schedule1.AppointmentDate = DateTime.Now;
            schedule1.MaxParticipants = 30;
            schedule1.InstructorName = "Test Instructor1";
            schedule1.ClassType = "Beginner";

            ScheduleModel schedule2 = new ScheduleModel();
            schedule2.AppointmentDate = DateTime.Now;
            schedule2.MaxParticipants = 15;
            schedule2.InstructorName = "Test Instructor2";
            schedule2.ClassType = "Intermediate";

            ScheduleModel schedule3 = new ScheduleModel();
            schedule3.AppointmentDate = DateTime.Now;
            schedule3.MaxParticipants = 15;
            schedule3.InstructorName = "Test Instructor3";
            schedule3.ClassType = "Professional";

            return new ScheduleModel[] { schedule1, schedule2, schedule3 };
        }

    }
}
