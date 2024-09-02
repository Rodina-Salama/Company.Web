using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Data.Context.Configurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        void IEntityTypeConfiguration<Employee>.Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(50);
        }
    }


}
