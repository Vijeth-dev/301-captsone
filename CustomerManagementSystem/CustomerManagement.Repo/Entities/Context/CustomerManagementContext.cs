using CustomerManagement.Repo.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Repo.Entities.Context
{
    public class CustomerManagementContext : DbContext
    {
        public CustomerManagementContext()
        {
        }

        public CustomerManagementContext(DbContextOptions<CustomerManagementContext> options)
            : base(options)
        {
        }
        public string DB { get; set; }

        public CustomerManagementContext(string connectionString)
        {
            DB = connectionString;
        }
        public virtual DbSet<TblCustomer> TblCustomer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=VSSqlKibana\\SQLEXPRESS;Initial Catalog=CustomerManagement;Integrated Security=True",b=>b.MigrationsAssembly("CustomerManagement.Repo"));

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

           

            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.ToTable("tblCustomer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(225)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(225)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(225)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(225)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PasswordKey)
                   .IsRequired()
                   .HasMaxLength(225)
                   .HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");
            });
        }
    }
}
