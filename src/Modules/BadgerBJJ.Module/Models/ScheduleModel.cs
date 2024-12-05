using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.ContentManagement;

namespace BadgerBJJ.Module.Models
{
    public class ScheduleModel
    {
        public DateTime AppointmentDate { get; set; }
        public int MaxParticipants { get; set; }
        public List<string> RegisteredEmails { get; set; } = new List<string>();
        public string? InstructorName { get; set; }

        //change to enum later
        public string? ClassType { get; set; } // e.g., "Beginner", "Advanced"

        //used by background Task
        public string? Status { get; set; }
    }
}
