using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options): base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComments> ProjectComments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Todo: Definir as chaves primárias
            //Todo: Definir as chaves estrangeiras

            modelBuilder.Entity<Project>()
            .HasKey(p => p.Id);

            //O projeto tem 1 freelancer 
            //Um freelancer têm muitos projetos
            //Chave estrangeira so relacionamento -> IdFreelancer
            //Caso um relacionamento seja deletado, retringir o procedimento
            modelBuilder.Entity<Project>()
            .HasOne(p => p.Freelancer)
            .WithMany(f => f.FreelancerProjects)
            .HasForeignKey(p => p.IdFreelancer)
            .OnDelete(DeleteBehavior.Restrict);

             //O projeto tem 1 Cliente 
            //Um Client têm muitos projetos que ele é dono (OwnedProject)
            //Chave estrangeira so relacionamento -> IdClient
            //Caso um relacionamento seja deletado, retringir o procedimento
            modelBuilder.Entity<Project>()
            .HasOne(p => p.Client)
            .WithMany(c => c.OwnedProjects)
            .HasForeignKey(p => p.IdCliente)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectComments>()
            .HasKey(p => p.Id);

            modelBuilder.Entity<ProjectComments>()
            .HasOne(p => p.Project)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.IdProject)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectComments>()
            .HasOne(p => p.User)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.IdUser)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Skill>()
            .HasKey(s => s.Id);

            modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
            .HasMany(u => u.Skills)
            .WithOne()
            .HasForeignKey(u => u.IdSkill)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserSkill>()
            .HasKey(u => u.Id);
        }
    }
}