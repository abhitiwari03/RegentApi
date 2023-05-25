using System;
using System.Collections.Generic;

namespace RegentApi.Models
{
    public partial class ImageUpload
    {
        public int ImageId { get; set; }
        public string? ImageText { get; set; }
        public string? ImageName { get; set; }
        public string? Location { get; set; }
        public DateTime? Date { get; set; }
        public string? Note { get; set; }
    }
}
