namespace DevFreela.Application.Models.ViewModels
{
    public class UserSkillViewModel
    {
        public UserSkillViewModel(int idUser, int idSkill)
        {
            IdUser = idUser;
            IdSkill = idSkill;
        }

        public int IdUser { get; private set; }
        public int IdSkill { get; private set; }
    }
}