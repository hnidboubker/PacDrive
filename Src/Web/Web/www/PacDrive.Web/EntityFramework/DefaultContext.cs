using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using PacDrive.Web.Entities;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PacDrive.Web.EntityFramework
{
    public class DefaultContext : DbContext
    {
        public DefaultContext():base("Default")
        {
            
        }
        public IDbSet<User> Users { get; set; }
        public IDbSet<UserLogin> UserLogins { get; set; }
        public IDbSet<UserClaim> UserClaims { get; set; }
        public IDbSet<UserRole> UserRoles { get; set; }
        public IDbSet<Role> Roles { get; set; }

        public virtual ObjectContext ObjectContext()
        {
            return (this as IObjectContextAdapter).ObjectContext;
        }

        public virtual DbSet DbSet<T>(T entity) where T : class
        {
            return Set<T>();
        }

        public virtual int Commit()
        {
            return ObjectContext().SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DefaultContext>());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>()
                .HasMany(o => o.Logins)
                .WithRequired()
                .HasForeignKey(u => u.UserId);
            modelBuilder.Entity<User>()
                .HasMany(o => o.Claims)
                .WithRequired()
                .HasForeignKey(u => u.UserId);
            modelBuilder.Entity<User>()
                .HasMany(o => o.Roles)
                .WithRequired()
                .HasForeignKey(u => u.UserId);
            modelBuilder.Entity<User>().HasKey(o => new
            {
                Id = o.Id
            });
            modelBuilder.Entity<User>()
                .Property(o => o.UserName)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", 
                new IndexAnnotation(new IndexAttribute("UserNameIndex") 
                {
                    IsUnique = true 
                }));

            modelBuilder.Entity<UserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<UserLogin>().HasKey(o => new
            {
                UserId = o.UserId,
                LoginProvider = o.LoginProvider,
                ProviderKey = o.ProviderKey
            });
            modelBuilder.Entity<UserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<UserClaim>().HasKey(o => new
            {
                Id = o.Id,
                UserId = o.UserId,
                ClaimValue = o.ClaimValue,
                ClaimType = o.ClaimType
            });
            modelBuilder.Entity<UserRole>().ToTable("UserRole");
            modelBuilder.Entity<UserRole>().HasKey(o => new
            {
                UserId = o.UserId,
                RoleId = o.RoleId
            });
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Role>().HasKey(o => new
            {
                Id = o.Id
            });
            modelBuilder.Entity<Role>()
                .Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index",
                new IndexAnnotation(
                    new IndexAttribute("RoleNameIndex")
                    {
                        IsUnique = true
                    }));
            modelBuilder.Entity<Role>()
                .HasMany(o => o.Users).WithRequired().HasForeignKey(r => r.RoleId);
        }
    }
}