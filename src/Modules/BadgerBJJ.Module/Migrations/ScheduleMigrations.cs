using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.Data.Migration;
using System.Threading.Tasks;
using YesSql.Sql;
using BadgerBJJ.Module.Indexes;

namespace BadgerBJJ.Module.Migrations
{
    public class ScheduleMigrations : DataMigration
    {

        //creates additional index table that helps with searching and filtering schedule data efficiently
        // creates the actual database table based on the index
        public async Task<int> CreateAsync()
        {
            await SchemaBuilder.CreateMapIndexTableAsync<ScheduleIndex>(table => table
                .Column<string>(nameof(ScheduleIndex.AppointmentDate))
                .Column<string>(nameof(ScheduleIndex.MaxParticipants))
                .Column<string>(nameof(ScheduleIndex.InstructorName))
                .Column<string>(nameof(ScheduleIndex.ClassType))
                .Column<string>(nameof(ScheduleIndex.Status))
            );

            //represents the schema version number
            return 2;
        }
    }
}
