using Microsoft.EntityFrameworkCore;
using ServiceOrdersManagement.Domain.Entities;

namespace ServiceOrderManagement.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ServiceOrder> ServiceOrders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Configuração para o Value Object Client (propriedade owned)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceOrder>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.OwnsOne(e => e.Client, client =>
                {
                    client.Property(c => c.Name)
                          .HasColumnName("ClientName")
                          .IsRequired();

                    client.Property(c => c.Document)
                          .HasColumnName("ClientDocument")
                          .IsRequired();

                    client.Property(c => c.Email)
                          .HasColumnName("ClientEmail")
                          .IsRequired();

                    client.Property(c => c.Phone)
                          .HasColumnName("ClientPhone")
                          .IsRequired();
                });
                entity.Property(e => e.ServiceDescription)
                      .IsRequired();

                entity.Property(e => e.Value)
                      .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Status)
                      .IsRequired();

                entity.Property(e => e.CreatedAt)
                      .IsRequired();
            });
        }
    }
}
