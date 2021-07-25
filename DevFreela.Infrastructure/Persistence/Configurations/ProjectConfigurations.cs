using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            //Chave primária
            builder
            .HasKey(p => p.Id);

            //O projeto tem 1 freelancer 
            //Um freelancer têm muitos projetos
            //Chave estrangeira so relacionamento -> IdFreelancer
            //Caso um relacionamento seja deletado, retringir o procedimento
            builder
            .HasOne(p => p.Freelancer)
            .WithMany(f => f.FreelancerProjects)
            .HasForeignKey(p => p.IdFreelancer)
            .OnDelete(DeleteBehavior.Restrict);

             //O projeto tem 1 Cliente 
            //Um Client têm muitos projetos que ele é dono (OwnedProject)
            //Chave estrangeira so relacionamento -> IdClient
            //Caso um relacionamento seja deletado, retringir o procedimento
            builder
            .HasOne(p => p.Client)
            .WithMany(c => c.OwnedProjects)
            .HasForeignKey(p => p.IdCliente)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}