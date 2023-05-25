using System;
using System.Collections.Generic;

namespace RegentApi.Models
{
    public partial class CampaignMetaData
    {
        public int Id { get; set; }
        public bool ShowCampaignPage { get; set; }
        public bool IsPageAccessibleViaMenu { get; set; }
    }
}
