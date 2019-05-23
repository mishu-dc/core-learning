using LearningCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCore.Data.Configurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profile");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Designation)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.DOB)
                .IsRequired();

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Phone)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.Summary)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(p => p.FaceBookLink)
                .HasMaxLength(500);

            builder.Property(p => p.GitHubLink)
                .HasMaxLength(500);

            builder.Property(p => p.LeetCodeLink)
                .HasMaxLength(500);

            builder.Property(p => p.LinkedinLink)
                .HasMaxLength(500);

            builder.Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
