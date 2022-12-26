using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityManagementSystem_Final.Model;

namespace UniversityManagementSystem_Final.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        /// <summary>
        /// configuration for  teacher
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teacher", "uni");
            builder.Property(x => x.FirstName)
                .HasMaxLength(50);
            builder.Property(x => x.LastName)
                .HasMaxLength(50);
            builder.Property(x => x.PersonalId)
                .HasMaxLength(50);
        }
    }
}
