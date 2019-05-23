using LearningCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCore.Data.Configurations
{
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.ToTable("Experiences");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.StartDate)
                .IsRequired();

            builder.Property(e => e.EndDate)
                .IsRequired(false);

            builder.Property(e => e.IsCurrent)
                .HasDefaultValue(false);

            builder.Property(e => e.ProfileId)
                .IsRequired();

            builder.HasOne(e => e.Profile).WithMany(p => p.Experiences);

            builder.Property(e => e.CompanyLink)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Designation)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(e => e.Responsibilities);
        }
    }
}
