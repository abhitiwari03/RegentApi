using System;
using System.Collections.Generic;

namespace RegentApi.Models
{
    public partial class Registration
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? AssignmentId { get; set; }
        public string EmailAddress { get; set; } = null!;
        public string? PhoneNo { get; set; }
        public string? Motivation { get; set; }
        public string? Cvurl { get; set; }
        public string? ProjectRef { get; set; }
        public int ApplicationStatus { get; set; }
        public DateTime SignupDate { get; set; }
        public string? HourlyRate { get; set; }
        public string? ClientProjectRef { get; set; }
        public string? ModeOfInterview { get; set; }
        public string? FeedBack { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsAdminAdded { get; set; }
        public int? NewsId { get; set; }

        public virtual Assignment? Assignment { get; set; }
        public virtual News? News { get; set; }
    }
}
