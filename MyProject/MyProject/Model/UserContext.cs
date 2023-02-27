using Microsoft.EntityFrameworkCore;

namespace MyProject.Model
{
    public partial class UserContext : DbContext
    {
        public DbSet<Users> Users { get; set; } = null!;

        public DbSet<Type_Of_Organization> Type_Of_Organizations { get; set; } = null!;

        public DbSet<Organization> Organizations { get; set; } = null!;

        public DbSet<Roles> Roles { get; set; } = null!;

        public UserContext(DbContextOptions<UserContext> options)
           : base(options)
        {
            
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Type_Of_Organization>().HasData(
                new Type_Of_Organization { Id = 1, Type_Of ="Commercial"},
                new Type_Of_Organization { Id = 2, Type_Of = "Uncommercial" },
                new Type_Of_Organization { Id = 3, Type_Of = "Formal" },
                new Type_Of_Organization { Id = 4, Type_Of = "Informal" }
                );
            modelBuilder.Entity<Roles>().HasData(
                new Roles { Id=1, Name="Administrator", Can_Create_Documents=true, Can_Read_Documents=true, Can_Update_Documents=true},
                new Roles { Id = 2, Name = "Manager", Can_Create_Documents = true, Can_Read_Documents = true, Can_Update_Documents = false },
                new Roles { Id = 3, Name = "Moderator", Can_Create_Documents = true, Can_Read_Documents = false, Can_Update_Documents = false },
                new Roles { Id = 4, Name = "User", Can_Create_Documents = false, Can_Read_Documents = true, Can_Update_Documents = false },
                new Roles { Id = 5, Name = "Editor", Can_Create_Documents = false, Can_Read_Documents = true, Can_Update_Documents = false },
                new Roles { Id = 6, Name = "Guest", Can_Create_Documents = false, Can_Read_Documents = false, Can_Update_Documents = false },
                new Roles { Id = 7, Name = "Administrative Assistant", Can_Create_Documents = true, Can_Read_Documents = false, Can_Update_Documents = false },
                new Roles { Id = 8, Name = "Receptionist", Can_Create_Documents = false, Can_Read_Documents = true, Can_Update_Documents = false },
                new Roles { Id = 9, Name = "Accountant", Can_Create_Documents = true, Can_Read_Documents = true, Can_Update_Documents = false },
                new Roles { Id = 10, Name = "IT Technician", Can_Create_Documents = true, Can_Read_Documents = true, Can_Update_Documents = true }
                );
            modelBuilder.Entity<Organization>().HasData(
                new Organization { Id=1, Name = "MyOrganization", Type_Of_OrganizationId = 1 });
            modelBuilder.Entity<Users>().HasData(
                new Users { Id=1, Email="yarosh@gmail.com", Password="1111", OrganizationId=1, RolesId=1} );
     
        }
    }
}
