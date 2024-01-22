using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackendApi.Models
{
    public partial class dbapiContext : DbContext
    {
        public dbapiContext()
        {
        }

        public dbapiContext(DbContextOptions<dbapiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Block> Blocks { get; set; } = null!;
        public virtual DbSet<BlockType> BlockTypes { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<TextType> TextTypes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Video> Videos { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Block>(entity =>
            {
                entity.Property(e => e.BlockId).HasColumnName("BlockID");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.BlockName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BlockTypeId).HasColumnName("BlockTypeID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_by");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.TextBlock).HasColumnType("text");

                entity.Property(e => e.Title).IsUnicode(false);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Blocks)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Blocks__AuthorID__3E52440B");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Blocks)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Blocks__Category__3F466844");

                entity.HasOne(d => d.Feedback)
                    .WithMany(p => p.Blocks)
                    .HasForeignKey(d => d.FeedbackId)
                    .HasConstraintName("FK__Blocks__Feedback__5535A963");
            });

            modelBuilder.Entity<BlockType>(entity =>
            {
                entity.ToTable("BlockType");

                entity.Property(e => e.BlockTypeId).HasColumnName("BlockTypeID");

                entity.Property(e => e.BlockId).HasColumnName("BlockID");

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.TextTypeId).HasColumnName("TextTypeID");

                entity.Property(e => e.VideoId).HasColumnName("VideoID");

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.BlockTypes)
                    .HasForeignKey(d => d.BlockId)
                    .HasConstraintName("FK__BlockType__Block__4E88ABD4");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.BlockTypes)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK__BlockType__Image__571DF1D5");

                entity.HasOne(d => d.TextType)
                    .WithMany(p => p.BlockTypes)
                    .HasForeignKey(d => d.TextTypeId)
                    .HasConstraintName("FK__BlockType__TextT__4F7CD00D");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.BlockTypes)
                    .HasForeignKey(d => d.VideoId)
                    .HasConstraintName("FK__BlockType__Video__5629CD9C");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_by");

                entity.Property(e => e.Descrip)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.BlockId).HasColumnName("BlockID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_by");

                entity.Property(e => e.ParentCommentId).HasColumnName("ParentCommentID");

                entity.Property(e => e.TextComment)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.BlockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments__BlockI__4316F928");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments__UserID__4222D4EF");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.BlockId).HasColumnName("BlockID");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.DislikesCount).HasColumnName("Dislikes_count");

                entity.Property(e => e.LikesCount).HasColumnName("Likes_count");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.BlockId)
                    .HasConstraintName("FK__Feedback__BlockI__534D60F1");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK__Feedback__Commen__5441852A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__UserID__52593CB8");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.BlockId).HasColumnName("BlockID");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ImageURL");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.BlockId)
                    .HasConstraintName("FK__Images__BlockID__48CFD27E");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_by");

                entity.Property(e => e.Descrip)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TextType>(entity =>
            {
                entity.ToTable("TextType");

                entity.Property(e => e.TextTypeId).HasColumnName("TextTypeID");

                entity.Property(e => e.BlockId).HasColumnName("BlockID");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.Href)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.TextTypes)
                    .HasForeignKey(d => d.BlockId)
                    .HasConstraintName("FK__TextType__BlockI__4BAC3F29");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_by");

                entity.Property(e => e.Email)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__RoleID__398D8EEE");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.ToTable("Video");

                entity.Property(e => e.VideoId).HasColumnName("VideoID");

                entity.Property(e => e.BlockId).HasColumnName("BlockID");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VideoUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VideoURL");

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.BlockId)
                    .HasConstraintName("FK__Video__BlockID__45F365D3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
