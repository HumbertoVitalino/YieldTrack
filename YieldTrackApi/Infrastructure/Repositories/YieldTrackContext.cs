using Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class YieldTrackContext(
    DbContextOptions<YieldTrackContext> options
) : DbContext(options)
{
    public DbSet<FixedIncomeAsset> FixedIncomeAssets { get; private set; } = default!;
    public DbSet<PriceHistory> PriceHistories { get; private set; } = default!;
    public DbSet<User> Users { get; private set; } = default!;
    public DbSet<UserInvestment> UserInvestments { get; private set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<FixedIncomeAsset>(entity =>
        {
            entity.ToTable("FixedIncomeAssets");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.Issuer)
                .HasColumnName("issuer")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.MaturityDate)
                .HasColumnName("maturity_date")
                .IsRequired();

            entity.Property(e => e.FaceValue)
                .HasColumnName("face_value")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            entity.Property(e => e.CurrentRate)
                .HasColumnName("current_rate")
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            entity.Property(x => x.Code)
                .HasColumnName("code")
                .IsRequired();

            entity.Property(x => x.RateType)
                .HasColumnName("rate_type")
                .IsRequired();

            entity.HasMany(e => e.PriceHistory)
                .WithOne(p => p.Asset)
                .HasForeignKey(p => p.AssetId);

            entity.HasMany(e => e.Investments)
                .WithOne(i => i.Asset)
                .HasForeignKey(i => i.AssetId);
        });

        modelBuilder.Entity<PriceHistory>(entity =>
        {
            entity.ToTable("PriceHistory");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            entity.Property(e => e.AssetId)
                .HasColumnName("asset_id")
                .IsRequired();

            entity.Property(e => e.ReferenceDate)
                .HasColumnName("reference_date")
                .IsRequired();

            entity.Property(e => e.Price)
                .HasColumnName("price")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            entity.Property(e => e.Rate)
                .HasColumnName("rate")
                .HasColumnType("decimal(5,2)")
                .IsRequired();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(e => e.PasswordHash)
                .HasColumnName("password_hash")
                .IsRequired();

            entity.Property(e => e.PasswordSalt)
                .HasColumnName("password_salt")
                .IsRequired();

            entity.HasMany(e => e.Investments)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId);
        });

        modelBuilder.Entity<UserInvestment>(entity =>
        {
            entity.ToTable("UserInvestments");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            entity.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            entity.Property(e => e.AssetId)
                .HasColumnName("asset_id")
                .IsRequired();

            entity.Property(e => e.Quantity)
                .HasColumnName("quantity")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            entity.Property(e => e.PurchaseDate)
                .HasColumnName("purchase_date")
                .IsRequired();
        });
    }
}