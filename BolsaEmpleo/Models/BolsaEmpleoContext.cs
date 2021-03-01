using System;
using BolsaEmpleo.DTO;
using BolsaEmpleo.DTO.Category;
using BolsaEmpleo.DTO.Job;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity;
using BolsaEmpleo.DTO.Seguridad;
using BolsaEmpleo.DTO.User;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BolsaEmpleo.Models
{
    public partial class BolsaEmpleoContext : DbContext
    {
        public BolsaEmpleoContext()
        {
        }

        public BolsaEmpleoContext(DbContextOptions<BolsaEmpleoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Configuration> Configuration { get; set; }
        public virtual DbSet<Employer> Employer { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobCategory> JobCategory { get; set; }
        public virtual DbSet<JobCategoryJobPosition> JobCategoryJobPosition { get; set; }
        public virtual DbSet<JobCategoryPosition> JobCategoryPosition { get; set; }
        public virtual DbSet<JobPosition> JobPosition { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=.\\;Database=BolsaEmpleo;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<>(entity =>
            //{
            //    entity.HasNoKey();
            //});

            modelBuilder.Entity<UserReponse>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<JobByCategoryResponse>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<JobResponse>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<GetPositionsByCategoryResponse>(entity => {
                entity.HasNoKey();
            });

            //modelBuilder.Entity<GetCategoriesResponse>(entity =>
            //{
            //    entity.HasNoKey();
            //});

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.HasKey(e => e.IdConfiguration);

                entity.Property(e => e.IdConfiguration).HasColumnName("idConfiguration");

                entity.Property(e => e.ConfigutarionName)
                    .IsRequired()
                    .HasColumnName("configutarionName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employer>(entity =>
            {
                entity.HasKey(e => e.IdEmployer);

                entity.Property(e => e.IdEmployer)
                    .HasColumnName("idEmployer")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("createdBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnName("createdOn");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerName)
                    .IsRequired()
                    .HasColumnName("employerName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TelephoneNumber)
                    .IsRequired()
                    .HasColumnName("telephoneNumber")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Ubication)
                    .IsRequired()
                    .HasColumnName("ubication")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Employer)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employer_User");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.IdJob);

                entity.Property(e => e.IdJob)
                    .HasColumnName("idJob")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("createdBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnName("createdOn");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerId).HasColumnName("employerId");

                entity.Property(e => e.HowApply)
                    .IsRequired()
                    .HasColumnName("howApply")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JobName)
                    .IsRequired()
                    .HasColumnName("jobName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobType)
                    .IsRequired()
                    .HasColumnName("jobType")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PositionId).HasColumnName("positionId");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Ubication)
                    .IsRequired()
                    .HasColumnName("ubication")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employer)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.EmployerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_Employer");
            });

            modelBuilder.Entity<JobCategory>(entity =>
            {
                entity.HasKey(e => e.IdCategory);

                entity.Property(e => e.IdCategory)
                    .HasColumnName("idCategory")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("categoryName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<JobCategoryJobPosition>(entity =>
            {
                entity.HasKey(e => new { e.IdCategory, e.IdPosition });

                entity.ToTable("JobCategory_JobPosition");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.IdPosition).HasColumnName("idPosition");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.JobCategoryJobPosition)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobCategory_JobPosition_JobCategory");

                entity.HasOne(d => d.IdPositionNavigation)
                    .WithMany(p => p.JobCategoryJobPosition)
                    .HasForeignKey(d => d.IdPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobCategory_JobPosition_JobPosition");
            });

            modelBuilder.Entity<JobCategoryPosition>(entity =>
            {
                entity.HasKey(e => new { e.IdJob, e.IdCategory, e.IdPosition });

                entity.ToTable("Job_Category_Position");

                entity.Property(e => e.IdJob).HasColumnName("idJob");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.IdPosition).HasColumnName("idPosition");

                entity.HasOne(d => d.IdJobNavigation)
                    .WithMany(p => p.JobCategoryPosition)
                    .HasForeignKey(d => d.IdJob)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_Category_Position_Job");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.JobCategoryPosition)
                    .HasForeignKey(d => new { d.IdCategory, d.IdPosition })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_Category_Position_JobCategory_JobPosition");
            });

            modelBuilder.Entity<JobPosition>(entity =>
            {
                entity.HasKey(e => e.IdPosition);

                entity.Property(e => e.IdPosition)
                    .HasColumnName("idPosition")
                    .ValueGeneratedNever();

                entity.Property(e => e.PositionName)
                    .IsRequired()
                    .HasColumnName("positionName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser)
                    .HasColumnName("idUser")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("createdBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnName("createdOn");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasColumnName("userLogin")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserTypeId).HasColumnName("userTypeId");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserType");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.IdUserType);

                entity.Property(e => e.IdUserType).HasColumnName("idUserType");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasColumnName("typeName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
