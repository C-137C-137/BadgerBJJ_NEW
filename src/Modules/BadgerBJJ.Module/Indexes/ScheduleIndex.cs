using BadgerBJJ.Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesSql.Indexes;

namespace BadgerBJJ.Module.Indexes
{

    //defines the structure of what we want to index:
    public class ScheduleIndex : MapIndex
    {
        public DateTime AppointmentDate { get; set; }
        public int MaxParticipants { get; set; }
        public List<string> RegisteredEmails { get; set; } = new List<string>();
        public string? InstructorName { get; set; }
        public string? ClassType { get; set; } // e.g., "Beginner", "Advanced"

        //used by background Task
        public string? Status { get; set; }

    }

    //handles keeping the index up to date
    public class ScheduleIndexProvider : IndexProvider<ScheduleModel>
    {
        public override void Describe(DescribeContext<ScheduleModel> context) =>
            context.For<ScheduleIndex>()
                .Map(bjjclass =>
                    new ScheduleIndex
                    {
                        AppointmentDate = bjjclass.AppointmentDate,
                        MaxParticipants = bjjclass.MaxParticipants,
                        RegisteredEmails = bjjclass.RegisteredEmails,
                        ClassType = bjjclass.ClassType,
                        Status = bjjclass.Status,
                        

                    });
    }
}
