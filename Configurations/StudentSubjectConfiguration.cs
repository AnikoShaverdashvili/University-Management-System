using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityManagementSystem_Final.Model;

namespace UniversityManagementSystem_Final.Configurations
{
    public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        /// <summary>
        /// Configuration for studentsubject
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.ToTable("StudentSubject", "uni");
        }
    }
}
