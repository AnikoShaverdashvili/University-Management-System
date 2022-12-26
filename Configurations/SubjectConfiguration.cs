using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityManagementSystem_Final.Model;

namespace UniversityManagementSystem_Final.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        /// <summary>
        /// configuration for  subject
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
           
            builder.ToTable("Subject", "uni");
            builder.Property(x => x.Name)
                .HasMaxLength(50);
        }
    }
}
