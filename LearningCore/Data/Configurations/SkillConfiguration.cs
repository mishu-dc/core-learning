using LearningCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCore.Data.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skills");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Link)
                .HasMaxLength(500);

            builder.Property(s => s.IsHighlighted)
                .HasDefaultValue(false);

            builder.Property(s => s.Serial)
                .IsRequired();

            builder.HasOne(p => p.Profile).WithMany(p => p.Skills);

            builder.Property(p => p.ProfileId).IsRequired();
        }
    }
}
