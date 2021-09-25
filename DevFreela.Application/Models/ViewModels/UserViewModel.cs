using System;

namespace DevFreela.Application.Models.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int id, string fullName, string email, string role, DateTime createdAt)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Role = role;
            CreatedAt = createdAt;
        }

        public int Id { get; set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}