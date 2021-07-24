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
            //Todo 1: Configuração da Tabela
            //Todo 1.1: Definir as chaves primárias da enditade (em uma nova construção de modelo "modelBuilder<T>()")

            //Todo 2: Configurar o relacionamento
            //Todo 2.1: Criar a propriedade que representa a chave estrangeira na classe que representa a entidade (caso não exista)
            //Todo 2.2: Definir o relacionamento da entidade com outra tabela (em uma nova construção de modelo "modelBuilder<T>()")
            //Todo 2.3: Definir a cardinalidade e criar a propriedade de navegação (Ex: Freelancer é um User da tabela Project)
            //Todo 2.4: Definir a chave estrangeira desse relacionamento (Ex: IdFreelance é a chave primária da tabela User "Pela herança Id receberá IdFreelacer")
            //Todo 2.5: Definir restrições quando tiver uma operação de "OnDelete"
            
            
#region  Project
            //Chave primária
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
#endregion

#region ProjectComments
            //Chave primária
            modelBuilder.Entity<ProjectComments>()
            .HasKey(p => p.Id);

            //O ProjectComments tem 1 projeto
            //O projeto tem muitos comentários 
            //Chave estrangeira so relacionamento -> IdProject
            //Caso um relacionamento seja deletado, retringir o procedimento
            modelBuilder.Entity<ProjectComments>()
            .HasOne(p => p.Project)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.IdProject)
            .OnDelete(DeleteBehavior.Restrict);

            //O ProjectComments tem 1 Usuário
            //O Usuário tem muitos comentários 
            //Chave estrangeira so relacionamento -> IdUser
            //Caso um relacionamento seja deletado, retringir o procedimento
            modelBuilder.Entity<ProjectComments>()
            .HasOne(p => p.User)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.IdUser)
            .OnDelete(DeleteBehavior.Restrict);
#endregion

#region User
            //Chave primária
            modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

            //O User tem muitas skills (UserSkill)
            //?A UserSkill tem um usuário?
            //Chave estrangeira so relacionamento -> IdSkill
            //Caso um relacionamento seja deletado, retringir o procedimento
            modelBuilder.Entity<User>()
            .HasMany(u => u.Skills)
            .WithOne()
            .HasForeignKey(u => u.IdSkill)
            .OnDelete(DeleteBehavior.Restrict);
#endregion

#region Skill
            //Chave primária
            modelBuilder.Entity<Skill>()
            .HasKey(s => s.Id);
#endregion

#region UserSkill
            //Chave primária
            modelBuilder.Entity<UserSkill>()
            .HasKey(u => u.Id);
#endregion
        }
    }
}