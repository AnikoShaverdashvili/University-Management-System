using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityManagementSystem_Final.Model;

namespace UniversityManagementSystem_Final.Configurations
{
    public class SemesterConfiguration : IEntityTypeConfiguration<Semester>
    {
        /// <summary>
        /// COnfiguration for semester
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Semester> builder)
        {
            builder.ToTable("Semester", "uni");
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property<DateTime>("StartDate")
                .HasColumnName(@"StartDate")
                .HasColumnType(@"datetime")
                .IsRequired();
            builder.Property<DateTime>("EndDate")
                .HasColumnName(@"EndDate")
                .HasColumnType(@"datetime")
                .IsRequired();
        }
    }
}