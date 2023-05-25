using System;
using System.Collections.Generic;

namespace RegentApi.Models
{
    public partial class Group
    {
        public Group()
        {
            News = new HashSet<News>();
        }

        public int Id { get; set; }
        public string? GroupName { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
