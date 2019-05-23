using LearningCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCore.Data.Configurations
{
    public class PublicationConfiguration : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> builder)
        {
            builder.ToTable("Publications");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Link)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.Property(p => p.ProfileId)
                .IsRequired();

            builder.Property(p => p.PublicationDate)
                .IsRequired(false);

            builder.Property(p => p.Serial)
                .IsRequired();

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.Description)
                .IsRequired(false)
                .HasMaxLength(int.MaxValue);

            builder.HasOne(p => p.Profile).WithMany(p => p.Publications);
        }
    }
}
