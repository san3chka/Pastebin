using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entity;

namespace Persistence;

public class PastebinContext(DbContextOptions<PastebinContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Paste> Pastes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new PasteConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Pastes)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
    }
}

public class PasteConfiguration : IEntityTypeConfiguration<Paste>
{
    public void Configure(EntityTypeBuilder<Paste> builder)
    {
        builder.HasKey(x => x.Id);
    }
}