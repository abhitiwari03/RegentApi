﻿using System;
using System.Collections.Generic;

namespace RegentApi.Models
{
    public partial class UserLogin
    {
        public string LoginProvider { get; set; } = null!;
        public string ProviderKey { get; set; } = null!;
        public string UserId { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
