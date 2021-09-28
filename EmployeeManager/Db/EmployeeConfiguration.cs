using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManager.Db
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasIndex(k => k.Id);
            builder.Property(k => k.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(ln => ln.LastName)
                .IsRequired();
            builder.HasOne(p => p.Position)
                .WithMany(e => e.Employees)
                .HasForeignKey(fk => fk.PositionId);
        }
    }
}