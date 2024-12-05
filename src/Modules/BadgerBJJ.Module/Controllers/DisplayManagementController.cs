using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadgerBJJ.Module.Models;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.ModelBinding;



namespace BadgerBJJ.Module.Controllers
{
    public class DisplayManagementController : Controller, IUpdateModel
    {
        //Manages how content gets displayed
        private readonly IDisplayManager<ScheduleModel> ScheduleDisplayManager;

        public DisplayManagementController(IDisplayManager<ScheduleModel> ScheduleDisplayManager)
        {
           this.ScheduleDisplayManager = ScheduleDisplayManager;
        }

        //controller action method --> DisplayScheduleShape view
        public ActionResult DisplaySheduleShape()
        {
            return View();
        }

        public async Task<IActionResult> DisplayDemoSchedule()
        {
            var schedule = CreateDemoSchedule();


            //transforms the schedule model into a renderable shape
            var scheduleShape = await ScheduleDisplayManager.BuildDisplayAsync(schedule, this);


            return View(scheduleShape);
        }

        private static ScheduleModel CreateDemoSchedule()
        {
            ScheduleModel schedule = new ScheduleModel();
            schedule.AppointmentDate = DateTime.Now;
            schedule.MaxParticipants = 30;
            schedule.InstructorName = "Test Instructor";
            schedule.ClassType = "Beginner";

            return schedule;
        }
    }
}
