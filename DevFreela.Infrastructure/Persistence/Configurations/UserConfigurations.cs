using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
             //Chave primária
            builder
            .HasKey(u => u.Id);

            //O User tem muitas skills (UserSkill)
            //A UserSkill tem um usuário
            //Chave estrangeira so relacionamento -> IdSkill
            //Caso um relacionamento seja deletado, retringir o procedimento
            builder
            .HasMany(u => u.Skills)
            .WithOne()
            .HasForeignKey(u => u.IdSkill)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}