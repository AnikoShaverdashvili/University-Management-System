using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using UniversityManagementSystem_Final.Model;

namespace UniversityManagementSystem_Final.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        /// <summary>
        /// Cofisgration for student
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student", "uni");
            builder.Property(x => x.FirstName)
                .HasMaxLength(50);
            builder.Property(x => x.LastName)
                .HasMaxLength(50);
            builder.Property(x => x.PersonalId)
                .HasMaxLength(50);
            builder.HasOne(x => x.Department).WithMany(y => y.Students).HasForeignKey(z => z.DepartmentId);
        }
    }
}