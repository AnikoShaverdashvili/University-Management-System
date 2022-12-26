using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem_Final.Model;

namespace UniversityManagementSystem_Final.Configurations
{
    public class BalanceConfiguration: IEntityTypeConfiguration<Balance>
    {
       /// <summary>
       /// Configuration for Balance
       /// </summary>
       /// <param name="builder"></param>
            public void Configure(EntityTypeBuilder<Balance> builder)
            {
            builder.ToTable("Balance", "uni");
            builder.Property(x => x.Amount)
                .HasPrecision(18, 2);
            builder.Property(x => x.Debth)
                .HasPrecision(18, 2);
            }
        }
    }

