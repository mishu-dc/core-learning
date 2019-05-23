using LearningCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCore.Data.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(p => p.DemoLink)
                .HasMaxLength(500);

            builder.Property(p => p.GitHubLink)
                .HasMaxLength(500);

            builder.Property(p => p.Serial)
                .IsRequired();

            builder.HasOne(p => p.Profile).WithMany(p => p.Projects);

            builder.Property(p => p.ProfileId).IsRequired();
        }
    }
}
