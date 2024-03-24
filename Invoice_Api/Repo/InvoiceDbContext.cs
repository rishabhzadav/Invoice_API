using Invoice_Api.Repo.Modal;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Api.Repo
{
    public class InvoiceDbContext : DbContext
    {
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options)
        {

        }

        public DbSet<item> items { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceItem>()
                .HasOne(i => i.Invoice)
                .WithMany(i => i.InvoiceItems)
                .HasForeignKey(i => i.InvoiceNo)
                .IsRequired();

            modelBuilder.Entity<InvoiceItem>()
        .HasKey(i2 => new { i2.InvoiceNo, i2.ItemCode });

                    modelBuilder.Entity<InvoiceItem>()
              .Ignore(ii => ii.Invoice);
        }

    }
}
