using System;
using DevFreela.Core.Enums;

namespace DevFreela.Application.Models.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string title, string description, decimal? totalCost, DateTime? startedAt, DateTime? finisheAt, string clientFullName, string freelancerFullName)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            StartedAt = startedAt;
            FinisheAt = finisheAt;
            ClientFullName = clientFullName;
            FreelancerFullName = freelancerFullName;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal? TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinisheAt { get; private set; }
        public string ClientFullName { get; private set; }
        public string FreelancerFullName { get; private set; }
    }
}