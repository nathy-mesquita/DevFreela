
### Camada de `Infraestructure`

![image](https://user-images.githubusercontent.com/19518771/128959026-ac60855c-b376-4567-98f1-8b8cb4549c16.png)


### Configurações de persistência utilizando `Migrations`
![image](https://user-images.githubusercontent.com/19518771/128959489-3e4f8914-ad51-43f6-8921-64b74470cfd0.png)


> Para não ficar com a classe de DbContext com várias configurações contendo todas as tabelas (entidades) e suas propriedades. 

>Realizamos a  implementação do `IEntityTypeConfiguration<T>`, onde T é a classe a ser configurada, e migrar o código para o ela. 

Exemplo: `Project`

Criando a classe e implementado `IEntityTypeConfiguration<T>` 

```csharp
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
        }
    }
}
```

O `builder` é o objeto direto daquela entidade, então não precisaremos utilizar o `modelBuilder.Entity<Project>()` 

```csharp
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
```

Na classe DevFreelaDbContext dentro do método `OnModelCreating` Utilizar reflection para pegar as configurações implementadas por Assembly


`DevFreelaDbContext` refatorado: 

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{            
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
```

### Modelo de Entidade Relacionamento - MER 
![image](https://user-images.githubusercontent.com/19518771/126908854-7fefd5bb-b970-4fbd-86e8-79cc05f895f2.png)