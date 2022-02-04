using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;
using System;

namespace Infrastructure.Persistence.Configurations
{

    /// <summary>
    /// Summary description for TestConfiguration
    /// </summary>
    public class TestConfiguration : IEntityTypeConfiguration<TestEntity>
    {
        public void Configure(EntityTypeBuilder<TestEntity> builder)
        {
            builder.Property(e => e.Id)
                .IsRequired()
                .HasMaxLength(50);
        }

    }
}