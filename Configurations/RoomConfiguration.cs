using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityManagementSystem_Final.Model;

namespace UniversityManagementSystem_Final.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        /// <summary>
        /// Configuration for room
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Room", "uni");
            builder.Property(x => x.Description)
                .HasMaxLength(50);
        }
    }
}
