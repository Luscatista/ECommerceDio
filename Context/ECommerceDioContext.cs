using ECommerceDio.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDio.Context;

public class ECommerceDioContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Role> Roles { get; set; }

    private IConfiguration _configuration;

    public ECommerceDioContext(DbContextOptions<ECommerceDioContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connection = _configuration.GetConnectionString("ConnectionStrings")?.ToString();
            if (!string.IsNullOrEmpty(connection))
            {
                optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name).IsRequired().HasMaxLength(100).IsUnicode(false);

            entity.HasIndex(p => p.Name).IsUnique();

            entity.Property(p => p.Description).HasMaxLength(255).IsUnicode(false);

            entity.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)").HasPrecision(18,2);

            entity.Property(p => p.AvaiableStock).IsRequired();

        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Name).IsRequired().HasMaxLength(100).IsUnicode(false);

            entity.Property(c => c.Email).IsRequired().HasMaxLength(100).IsUnicode(false);

            entity.HasIndex(c => c.Email).IsUnique();

            entity.Property(c => c.Password).IsRequired().HasMaxLength(255).IsUnicode(false);

            entity.HasOne(c => c.Role).WithMany(r => r.Clients).HasForeignKey(c => c.RoleId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(o => o.Id);

            entity.Property(o => o.Status).IsRequired().IsUnicode(false);

            entity.Property(o => o.TotalPrice).HasColumnType("decimal(18,2)").HasPrecision(18,2);

            entity.Property(o => o.ClientId).IsRequired();

            entity.Property(o => o.CreationDate).IsRequired();

            entity.HasOne(o => o.Client).WithMany(c => c.Orders).HasForeignKey(o => o.ClientId);
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(o => o.Id);

            entity.HasOne(o => o.Order).WithMany(x => x.OrderItems).HasForeignKey(o => o.OrderId);

            entity.HasOne(o => o.Product).WithMany(x => x.OrderItems).HasForeignKey(o => o.ProductId);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Status).IsRequired().IsUnicode(false);

            entity.Property(p => p.MethodPayment).IsUnicode(false);

            entity.Property(p => p.PaymentDate).IsRequired();

            entity.HasOne(p => p.Order).WithMany(o => o.Payments).HasForeignKey(p => p.OrderId);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(r => r.Id);

            entity.Property(r => r.RoleDescription).IsRequired().HasMaxLength(100).IsUnicode(false);

            entity.HasIndex(r => r.RoleDescription).IsUnique();
        });

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Violão",
                Description = "Violão de 6 cordas em nylon",
                Price = 200,
                AvaiableStock = 20
            }
        );

        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = 1,
                RoleDescription = "Administrator"
            }
        );
    }
}