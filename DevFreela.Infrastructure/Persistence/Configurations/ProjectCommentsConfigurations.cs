using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectCommentsConfigurations : IEntityTypeConfiguration<ProjectComments>
    {
        public void Configure(EntityTypeBuilder<ProjectComments> builder)
        {
             //Chave primária
            builder
            .HasKey(p => p.Id);

            //O ProjectComments tem 1 projeto
            //O projeto tem muitos comentários 
            //Chave estrangeira so relacionamento -> IdProject
            //Caso um relacionamento seja deletado, retringir o procedimento
            builder
            .HasOne(p => p.Project)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.IdProject)
            .OnDelete(DeleteBehavior.Restrict);

            //O ProjectComments tem 1 Usuário
            //O Usuário tem muitos comentários 
            //Chave estrangeira so relacionamento -> IdUser
            //Caso um relacionamento seja deletado, retringir o procedimento
            builder
            .HasOne(p => p.User)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.IdUser)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}