using LearningCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCore.Data.Configurations
{
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.ToTable("Educations");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Degree)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.PassingYear)
                .IsRequired(false);

            builder.Property(e => e.ProfileId)
                .IsRequired();

            builder.HasOne(e => e.Profile).WithMany(p => p.Educations);

            builder.Property(e => e.Serial)
                .IsRequired();

            builder.Property(e => e.UniversityAddress)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.UniversityLink)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.UniversityName)
                .IsRequired()
                .HasMaxLength(500);            
        }
    }
}
