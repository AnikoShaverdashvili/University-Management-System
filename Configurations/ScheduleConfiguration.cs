using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityManagementSystem_Final.Model;

namespace UniversityManagementSystem_Final.Configurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        /// <summary>
        /// Configuraton for schedule
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedule", "uni");
            builder.Property<DateTime>("StartTime")
                .HasColumnName(@"StartTime")
                .HasColumnType(@"time")
                .IsRequired()
                .HasConversion(v => v.TimeOfDay, v => DateTime.Now.Date.Add(v));
            builder.Property<DateTime>("EndTime")
                .HasColumnName(@"EndTime")
                .HasColumnType(@"time")
                .IsRequired()
                .HasConversion(v => v.TimeOfDay, v => DateTime.Now.Date.Add(v));
        }
    }
}