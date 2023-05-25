using System;
using System.Collections.Generic;

namespace RegentApi.Models
{
    public partial class JobProfile
    {
        public int Id { get; set; }
        public string? RoleName { get; set; }
        public string? MenuButtonName { get; set; }
        public string? Url { get; set; }
        public string? PageTitle { get; set; }
        public string? MetaKeyword { get; set; }
        public string? MetaDescription { get; set; }
        public string? PageHeading { get; set; }
        public string? CoverPhotoUrl { get; set; }
        public string? HtmlContent { get; set; }
        public string? ContactFormHeading { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? SalaryTitle { get; set; }
        public string? SalaryDescription { get; set; }
    }
}
