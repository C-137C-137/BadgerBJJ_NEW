using BadgerBJJ.Module.Models;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgerBJJ.Module.Drivers
{
    public class ScheduleDisplayDriver : DisplayDriver<ScheduleModel>
    {

        //controls how different parts of a BJJ class schedule are displayed
        //each View() call assigns a specific location using .Location() for placement
        public override IDisplayResult Display(ScheduleModel model, BuildDisplayContext context) =>
            Combine(
                View($"{nameof(ScheduleModel)}_Display_DateTime", model)
                    .Location("DateTime: 1"),
                View($"{nameof(ScheduleModel)}_Display_Instructor", model)
                    .Location("Instructor: 1"),
                View($"{nameof(ScheduleModel)}_Display_ClassType", model)
                    .Location("ClassType: 1"),
                View($"{nameof(ScheduleModel)}_Display_MaxParticipants", model)
                    .Location("MaxParticipants: 1"),
                View($"{nameof(ScheduleModel)}_Display_CurrentParticipants", model)
                    .Location("CurrentParticipants: 1"),
                View($"{nameof(ScheduleModel)}_Display_Status", model)
                    .Location("Status", "Content: 1")
            );
    }
}
