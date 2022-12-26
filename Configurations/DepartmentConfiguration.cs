using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityManagementSystem_Final.Model;

namespace UniversityManagementSystem_Final.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        /// <summary>
        /// Configuration for Departments
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department", "uni");
            builder.Property(x => x.Name)
                .HasMaxLength(50);
        }
    }
}
