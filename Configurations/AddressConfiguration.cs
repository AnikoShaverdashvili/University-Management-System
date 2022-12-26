using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityManagementSystem_Final.Model;

namespace UniversityManagementSystem_Final.Configurations
{
    /// <summary>
    /// Configuration for Address
    /// </summary>
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        /// <summary>
        /// configuration for address
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address", "uni");
            builder.Property(x => x.Address1).HasMaxLength(100);
            builder.Property(x => x.Address2).HasMaxLength(50);
        }
    }
}
