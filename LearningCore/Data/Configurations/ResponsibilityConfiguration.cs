using LearningCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCore.Data.Configurations
{
    public class ResponsibilityConfiguration : IEntityTypeConfiguration<Responsibility>
    {
        public void Configure(EntityTypeBuilder<Responsibility> builder)
        {
            builder.ToTable("Responsibilities");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(r => r.ExperienceId)
                .IsRequired();

            builder.HasOne(r => r.Experience).WithMany(e => e.Responsibilities);

            builder.Property(r => r.Serial)
                .IsRequired();
        }
    }
}
