using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ComicBookShop.Model.Entity;

namespace ComicBookShop.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().ToTable("address");
            modelBuilder.Entity<CartItem>().ToTable("cartitem");
            modelBuilder.Entity<ComicBook>().ToTable("comicbook");
            modelBuilder.Entity<Order>().ToTable("order");
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<OrderComicBook>().ToTable("ordercomicbook");

            modelBuilder.Entity<Address>().HasKey(a => a.Id).HasName("PK_address");
            modelBuilder.Entity<CartItem>().HasKey(c => c.Id).HasName("PK_cartitem");
            modelBuilder.Entity<ComicBook>().HasKey(cb => cb.Id).HasName("PK_comicbook");
            modelBuilder.Entity<Order>().HasKey(o => o.Id).HasName("PK_order");
            modelBuilder.Entity<User>().HasKey(u => u.Id).HasName("PK_user");
            modelBuilder.Entity<OrderComicBook>().HasKey(o => new { o.OrderId,o.ComicBookId}).HasName("PK_ordercomicbook");

            
            
            modelBuilder.Entity<Address>().Property(a => a.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Address>().Property(a => a.Street).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<Address>().Property(a => a.Number).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Address>().Property(a => a.Details).HasColumnType("nvarchar(255)").IsRequired();

            modelBuilder.Entity<CartItem>().Property(a => a.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<CartItem>().Property(a => a.Quantity).HasColumnType("int").IsRequired();

            modelBuilder.Entity<ComicBook>().Property(a => a.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<ComicBook>().Property(a => a.ComicType).HasConversion<string>();
            modelBuilder.Entity<ComicBook>().Property(a => a.Title).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<ComicBook>().Property(a => a.Author).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<ComicBook>().Property(a => a.Genre).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<ComicBook>().Property(a => a.Description).HasColumnType("text").IsRequired();
            modelBuilder.Entity<ComicBook>().Property(a => a.Price).HasColumnType("int").IsRequired();
            modelBuilder.Entity<ComicBook>().Property(a => a.LaunchDate).HasColumnType("datetime").IsRequired();

            modelBuilder.Entity<Order>().Property(a => a.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Order>().Property(a => a.Details).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<Order>().Property(a => a.UUID).HasColumnType("nvarchar(255)").IsRequired();


            modelBuilder.Entity<User>().Property(a => a.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<User>().Property(a => a.FirstName).HasColumnType("nvarchar(255)");
            modelBuilder.Entity<User>().Property(a => a.LastName).HasColumnType("nvarchar(255)");
            modelBuilder.Entity<User>().Property(a => a.Username).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<User>().Property(a => a.Password).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<User>().Property(a => a.Email).HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<User>().Property(a => a.PhoneNumber).HasColumnType("nvarchar(255)");


            modelBuilder.Entity<User>().HasOne(a => a.DeliveryAddress)
                .WithMany(a => a.UserDeliveries);
            modelBuilder.Entity<Order>().HasOne(a => a.DeliveryAddress)
                .WithMany(a => a.Orders)
                .IsRequired();
            modelBuilder.Entity<CartItem>().HasOne(a => a.CorrespondingComicBook)
                .WithMany(a => a.CartItems)
                .IsRequired();
            modelBuilder.Entity<CartItem>().HasOne(a => a.InUsersCart)
                .WithMany(a => a.CartItems);
            modelBuilder.Entity<OrderComicBook>().HasOne(a => a.OrderContaining)
                .WithMany(a => a.OrderComicBooks)
                .IsRequired();
            modelBuilder.Entity<OrderComicBook>().HasOne(a => a.ComicBookContained)
                .WithMany(a => a.OrderComicBooks)
                .IsRequired();

            base.OnModelCreating(modelBuilder);


        }

        public DbSet<User> Users { get; set; }
        public DbSet<OrderComicBook> OrderComicBooks { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ComicBook> ComicBooks { get; set; }
    }
}
