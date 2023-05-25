using System;
using System.Collections.Generic;

namespace RegentApi.Models
{
    public partial class News
    {
        public News()
        {
            NewsSignups = new HashSet<NewsSignup>();
            Registrations = new HashSet<Registration>();
        }

        public int Id { get; set; }
        public string? NewsType { get; set; }
        public DateTime? Date { get; set; }
        public int? UserDefinedRank { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentLocation { get; set; }
        public string? BigImage { get; set; }
        public string? SmallImage { get; set; }
        public string? Header { get; set; }
        public string? SummaryText { get; set; }
        public string? DetailedText { get; set; }
        public DateTime? EventDate { get; set; }
        public string? EventAddress { get; set; }
        public bool? RegistrationClosed { get; set; }
        public string? EventRegistrationUrl { get; set; }
        public string? LinkType { get; set; }
        public int? LinkedNewsId { get; set; }
        public int? LinkedGroupId { get; set; }
        public int? GroupNewsOrder { get; set; }
        public bool? HideOnListPage { get; set; }
        public string? CustomUrl { get; set; }
        public bool? IsCustomUrl { get; set; }
        public bool? IsJobClosed { get; set; }
        public int? GroupId { get; set; }

        public virtual Group? Group { get; set; }
        public virtual ICollection<NewsSignup> NewsSignups { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }
    }
}
