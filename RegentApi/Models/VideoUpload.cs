using System;
using System.Collections.Generic;

namespace RegentApi.Models
{
    public partial class VideoUpload
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public string? Note { get; set; }
        public DateTime? Date { get; set; }
    }
}
