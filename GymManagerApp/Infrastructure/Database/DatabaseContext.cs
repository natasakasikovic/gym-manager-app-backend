﻿using GymManagerApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GymManagerApp.Infrastructure;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<TrainingType> TrainingTypes { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<User> Users{ get; set; }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}