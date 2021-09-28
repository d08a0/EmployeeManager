using EmployeeManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Db
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id)
            .ValueGeneratedOnAdd().IsRequired();
            builder.Property(n => n.Name).IsRequired();
        }
    }
}