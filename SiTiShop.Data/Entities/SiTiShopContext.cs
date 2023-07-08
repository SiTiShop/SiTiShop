using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SiTiShop.Data.Entities
{
    public partial class SiTiShopContext : DbContext
    {
        public SiTiShopContext()
        {
        }

        public SiTiShopContext(DbContextOptions<SiTiShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCart> TblCarts { get; set; } = null!;
        public virtual DbSet<TblCartDetail> TblCartDetails { get; set; } = null!;
        public virtual DbSet<TblCategory> TblCategories { get; set; } = null!;
        public virtual DbSet<TblImage> TblImages { get; set; } = null!;
        public virtual DbSet<TblOrder> TblOrders { get; set; } = null!;
        public virtual DbSet<TblOrderDetail> TblOrderDetails { get; set; } = null!;
        public virtual DbSet<TblPlace> TblPlaces { get; set; } = null!;
        public virtual DbSet<TblProduct> TblProducts { get; set; } = null!;
        public virtual DbSet<TblProductItem> TblProductItems { get; set; } = null!;
        public virtual DbSet<TblReward> TblRewards { get; set; } = null!;
        public virtual DbSet<TblRole> TblRoles { get; set; } = null!;
        public virtual DbSet<TblSize> TblSizes { get; set; } = null!;
        public virtual DbSet<TblTransaction> TblTransactions { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-OD6026O;Initial Catalog=SiTiShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCart>(entity =>
            {
                entity.ToTable("tblCart");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblCarts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblCart__userId__3D5E1FD2");
            });

            modelBuilder.Entity<TblCartDetail>(entity =>
            {
                entity.ToTable("tblCartDetail");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CartId).HasColumnName("cartId");

                entity.Property(e => e.ProductItemId).HasColumnName("productItemId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.TblCartDetails)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblCartDe__cartI__3E52440B");

                entity.HasOne(d => d.ProductItem)
                    .WithMany(p => p.TblCartDetails)
                    .HasForeignKey(d => d.ProductItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblCartDe__produ__3F466844");
            });

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.ToTable("tblCategory");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasMaxLength(511)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<TblImage>(entity =>
            {
                entity.ToTable("tblImage");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("imageUrl");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.ToTable("tblOrder");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate");

                entity.Property(e => e.Description)
                    .HasMaxLength(511)
                    .HasColumnName("description");

                entity.Property(e => e.PlaceId).HasColumnName("placeId");

                entity.Property(e => e.PointGain).HasColumnName("pointGain");

                entity.Property(e => e.PointUsed).HasColumnName("pointUsed");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.PlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblOrder__placeI__403A8C7D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblOrder__userId__412EB0B6");
            });

            modelBuilder.Entity<TblOrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__tblOrder__0809335D2649B28F");

                entity.ToTable("tblOrderDetail");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("orderId");

                entity.Property(e => e.PricePerUnit).HasColumnName("pricePerUnit");

                entity.Property(e => e.ProductItemId).HasColumnName("productItemId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithOne(p => p.TblOrderDetail)
                    .HasForeignKey<TblOrderDetail>(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblOrderD__order__4222D4EF");

                entity.HasOne(d => d.ProductItem)
                    .WithMany(p => p.TblOrderDetails)
                    .HasForeignKey(d => d.ProductItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblOrderD__produ__4316F928");
            });

            modelBuilder.Entity<TblPlace>(entity =>
            {
                entity.ToTable("tblPlace");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Room).HasColumnName("room");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.ToTable("tblProduct");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Description)
                    .HasMaxLength(511)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblProducts)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblProduc__categ__440B1D61");
            });

            modelBuilder.Entity<TblProductItem>(entity =>
            {
                entity.ToTable("tblProductItem");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SizeId).HasColumnName("sizeId");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updateDate");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblProductItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblProduc__produ__44FF419A");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.TblProductItems)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblProduc__sizeI__45F365D3");
            });

            modelBuilder.Entity<TblReward>(entity =>
            {
                entity.ToTable("tblReward");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Point).HasColumnName("point");

                entity.Property(e => e.TotalPoint).HasColumnName("totalPoint");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblRewards)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblReward__userI__46E78A0C");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.ToTable("tblRole");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<TblSize>(entity =>
            {
                entity.ToTable("tblSize");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<TblTransaction>(entity =>
            {
                entity.ToTable("tblTransaction");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("paymentMethod");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TblTransactions)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblTransa__order__47DBAE45");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("tblUser");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(20)
                    .HasColumnName("fullname");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Username)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblUser__roleId__48CFD27E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
