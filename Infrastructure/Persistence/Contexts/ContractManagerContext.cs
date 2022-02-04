﻿using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection;

namespace Infrastructure.Persistence.Contexts
{

    public class ContractManagerContext : DbContext
    {
        public ContractManagerContext(DbContextOptions<ContractManagerContext> options) : base(options)
        {
        }

        public DbSet<TestEntity> TestEntity => Set<TestEntity>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

    }
}
