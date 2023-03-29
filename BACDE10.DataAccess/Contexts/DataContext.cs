using System;
using System.Collections.Generic;
using BACDE10.BusinessLogic.Interfaces.Services;
using BACDE10.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BACDE10.DataAccess.Contexts;

public class DataContext : DbContext
{
    private readonly IUserDetailsProvider _userDetailsProvider;
    public DataContext(DbContextOptions<DataContext> options, IUserDetailsProvider userDetailsProvider)
        : base(options)
    {
        _userDetailsProvider = userDetailsProvider;
    }

    public DbSet<ClientEntity> Clients { get; set; } = null!;
    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<StudentEntity> Students { get; set; } = null!;
    public DbSet<CategoryEntity> Categories { get; set; } = null!;
    public DbSet<CourseEntity> Courses { get; set; } = null!;
    public DbSet<CourseDetailsEntity> CourseDetails { get; set; } = null!;
    public DbSet<ExerciseEntity> Exercises { get; set; } = null!;
    public DbSet<ExerciseCaseEntity> ExerciseCases { get; set; } = null!;
    public DbSet<ExerciseSolutionEntity> ExerciseSolutions { get; set; } = null!;
    public DbSet<ExerciseExplanationEntity> ExerciseExplanations { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentEntity>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

        modelBuilder.Entity<UserEntity>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    {
        var userId = _userDetailsProvider.GetUserId();
        ApplyAuditableProperties(userId);

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override int SaveChanges()
    {
        var userId = _userDetailsProvider.GetUserId();
        ApplyAuditableProperties(userId);

        return base.SaveChanges();
    }

    private void ApplyAuditableProperties(Guid userId)
    {
        var addedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();
        var editedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();

        var utcNow = DateTime.UtcNow;

        const string createdDatePropertyName = nameof(AuditableEntity.CreatedDate);
        const string updatedDatePropertyName = nameof(AuditableEntity.UpdatedDate);
        const string createdByPropertyName = nameof(AuditableEntity.CreatedBy);
        const string updatedByPropertyName = nameof(AuditableEntity.UpdatedBy);

        addedEntities.ForEach(e =>
        {
            if (!e.Properties.ToList().Exists(p => p.Metadata.Name == createdDatePropertyName)) return;
            e.Property(createdDatePropertyName).CurrentValue = utcNow;
            e.Property(createdByPropertyName).CurrentValue = userId;
        });

        editedEntities.ForEach(e =>
        {
            if (!e.Properties.ToList().Exists(p => p.Metadata.Name == createdDatePropertyName)) return;
            e.Property(updatedDatePropertyName).CurrentValue = utcNow;
            e.Property(updatedByPropertyName).CurrentValue = userId;

            e.Property(createdDatePropertyName).IsModified = false;
            e.Property(createdByPropertyName).IsModified = false;
        });
    }
}
