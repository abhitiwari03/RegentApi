using System;
using System.Collections.Generic;

namespace RegentApi.Models
{
    public partial class NewsSignup
    {
        public int Id { get; set; }
        public int? NewsId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
        public DateTime? Date { get; set; }
        public short? Downloaded { get; set; }
        public string? AttachmentUrl { get; set; }

        public virtual News? News { get; set; }
    }
}
