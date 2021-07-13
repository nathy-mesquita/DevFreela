using System;

namespace DevFreela.Application.Models.InputModels
{
    public class NewUserInputModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}