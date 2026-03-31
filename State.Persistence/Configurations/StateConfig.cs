using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace State.Persistence.Configurations
{
    public class StateConfig
    {
        public void Configure(EntityTypeBuilder<States> builder)
        {
            builder.ToTable("States");

            builder.HasKey(s => s.Id);
            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(s => s.Code)
                .IsRequired()
                .HasMaxLength(5);
        }
    }
}
