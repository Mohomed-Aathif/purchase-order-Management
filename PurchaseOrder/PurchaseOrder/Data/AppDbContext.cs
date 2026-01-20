using Microsoft.EntityFrameworkCore;
using PurchaseOrder.Models;

namespace PurchaseOrder.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<PurchaseOrderEntity> PurchaseOrders => Set<PurchaseOrderEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PurchaseOrderEntity>()
            .HasIndex(p => p.PoNumber)
            .IsUnique();

        modelBuilder.Entity<PurchaseOrderEntity>()
            .Property(p => p.TotalAmount)
            .HasColumnType("decimal(18,2)");
    }
}
