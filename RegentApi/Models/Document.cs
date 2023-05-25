using System;
using System.Collections.Generic;

namespace RegentApi.Models
{
    public partial class Document
    {
        public int Id { get; set; }
        public string? DocumentLocation { get; set; }
        public DateTime? Date { get; set; }
        public string? Name { get; set; }
    }
}
