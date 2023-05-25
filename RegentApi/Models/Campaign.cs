using System;
using System.Collections.Generic;

namespace RegentApi.Models
{
    public partial class Campaign
    {
        public int Id { get; set; }
        public string? CampaignName { get; set; }
        public string? CampaignTitle { get; set; }
        public string? CampaignBlock1 { get; set; }
        public string? CampaignBlock2 { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
