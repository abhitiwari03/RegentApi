using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RegentApi.Models
{
    public partial class RegentDB_NewContext : DbContext
    {
        public RegentDB_NewContext()
        {
        }

        public RegentDB_NewContext(DbContextOptions<RegentDB_NewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<Assignment> Assignments { get; set; } = null!;
        public virtual DbSet<Campaign> Campaigns { get; set; } = null!;
        public virtual DbSet<CampaignMetaData> CampaignMetaDatas { get; set; } = null!;
        public virtual DbSet<Document> Documents { get; set; } = null!;
        public virtual DbSet<ElmahError> ElmahErrors { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<ImageUpload> ImageUploads { get; set; } = null!;
        public virtual DbSet<JobProfile> JobProfiles { get; set; } = null!;
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; } = null!;
        public virtual DbSet<News> News { get; set; } = null!;
        public virtual DbSet<NewsSignup> NewsSignups { get; set; } = null!;
        public virtual DbSet<Registration> Registrations { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserClaim> UserClaims { get; set; } = null!;
        public virtual DbSet<UserLogin> UserLogins { get; set; } = null!;
        public virtual DbSet<VideoUpload> VideoUploads { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=RegentDB_New;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.Property(e => e.AssignmentCloseReminderDate).HasColumnType("datetime");

                entity.Property(e => e.AssignmentEndDate).HasColumnType("datetime");

                entity.Property(e => e.AssignmentPublishDate).HasColumnType("datetime");

                entity.Property(e => e.AssignmentStartDate).HasColumnType("datetime");

                entity.Property(e => e.ClientProjectRef).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.HourlyRate).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ResponsibleUserId).HasMaxLength(100);

                entity.Property(e => e.Scope).HasMaxLength(100);

                entity.Property(e => e.Summary).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<ElmahError>(entity =>
            {
                entity.HasKey(e => e.ErrorId)
                    .HasName("PK_dbo.ELMAH_Error");

                entity.ToTable("ELMAH_Error");

                entity.Property(e => e.ErrorId).ValueGeneratedNever();

                entity.Property(e => e.AllXml).HasColumnType("ntext");

                entity.Property(e => e.Application).HasMaxLength(60);

                entity.Property(e => e.Host).HasMaxLength(50);

                entity.Property(e => e.Message).HasMaxLength(500);

                entity.Property(e => e.Sequence).ValueGeneratedOnAdd();

                entity.Property(e => e.Source).HasMaxLength(60);

                entity.Property(e => e.TimeUtc).HasColumnType("datetime");

                entity.Property(e => e.Type).HasMaxLength(100);

                entity.Property(e => e.User).HasMaxLength(50);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ImageUpload>(entity =>
            {
                entity.HasKey(e => e.ImageId)
                    .HasName("PK_dbo.ImageUploads");

                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<JobProfile>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasIndex(e => e.GroupId, "IX_Group_Id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("Group_Id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.News_dbo.Groups_Group_Id");
            });

            modelBuilder.Entity<NewsSignup>(entity =>
            {
                entity.HasIndex(e => e.NewsId, "IX_NewsId");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.NewsSignups)
                    .HasForeignKey(d => d.NewsId)
                    .HasConstraintName("FK_dbo.NewsSignups_dbo.News_NewsId");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasIndex(e => e.AssignmentId, "IX_AssignmentId");

                entity.HasIndex(e => e.NewsId, "IX_News_Id");

                entity.Property(e => e.ClientProjectRef).HasMaxLength(50);

                entity.Property(e => e.Cvurl).HasColumnName("CVUrl");

                entity.Property(e => e.EmailAddress).HasMaxLength(100);

                entity.Property(e => e.FeedBack).HasMaxLength(1000);

                entity.Property(e => e.HourlyRate).HasMaxLength(100);

                entity.Property(e => e.ModeOfInterview).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.NewsId).HasColumnName("News_Id");

                entity.Property(e => e.SignupDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Assignment)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.AssignmentId)
                    .HasConstraintName("FK_dbo.Registrations_dbo.Assignments_AssignmentId");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.NewsId)
                    .HasConstraintName("FK_dbo.Registrations_dbo.News_News_Id");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.Name, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(256);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").HasConstraintName("FK_dbo.UserRoles_dbo.Roles_RoleId"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").HasConstraintName("FK_dbo.UserRoles_dbo.Users_UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("PK_dbo.UserRoles");

                            j.ToTable("UserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_RoleId");

                            j.HasIndex(new[] { "UserId" }, "IX_UserId");

                            j.IndexerProperty<string>("UserId").HasMaxLength(128);

                            j.IndexerProperty<string>("RoleId").HasMaxLength(128);
                        });
            });

            modelBuilder.Entity<UserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.UserClaims_dbo.Users_UserId");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.UserLogins");

                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.UserLogins_dbo.Users_UserId");
            });

            modelBuilder.Entity<VideoUpload>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
