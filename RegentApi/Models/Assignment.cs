using System;
using System.Collections.Generic;

namespace RegentApi.Models
{
    public partial class Assignment
    {
        public Assignment()
        {
            Registrations = new HashSet<Registration>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string? Description { get; set; }
        public int ProjectRef { get; set; }
        public string? Location { get; set; }
        public DateTime? AssignmentEndDate { get; set; }
        public DateTime? AssignmentStartDate { get; set; }
        public DateTime? AssignmentPublishDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public int Status { get; set; }
        public string? Scope { get; set; }
        public string? ClientProjectRef { get; set; }
        public bool? WonDeal { get; set; }
        public int? CandidateId { get; set; }
        public decimal? HourlyRate { get; set; }
        public string? ResponsibleUserId { get; set; }
        public DateTime? AssignmentCloseReminderDate { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }
    }
}
