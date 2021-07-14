using System;
using System.Collections.Generic;
using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto APSNET Core", "Minha descrição de projeto ASPNET core", 1, 1, 1000),
                new Project("Meu projeto Micro Serviços", "Minha descrição de projeto Micro Serviços", 1, 1, 2000),
                new Project("Meu projeto React", "Minha descrição de projeto React", 1, 1, 3000)
            };
            Users = new List<User>
            {
                new User("Maria Gomes", "maria.gomes@gmail.com", new DateTime(1997, 12, 08)),
                new User("Antonia Julia", "antonia.julia@gmail.com", new DateTime(1992, 01, 01)),
                new User("Nathaly Mesquita", "nathaly.mesquita@gmail.com", new DateTime(1995, 05, 25))
            };
            Skills = new List<Skill>
            {
                new Skill(".Net Core"),
                new Skill("C#"),
                new Skill("SQL")
            };
        }
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<UserSkill> UserSkills { get; set; }
        public List<ProjectComments> ProjectComments { get; set; }
    }
}