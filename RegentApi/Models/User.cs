using System;
using System.Collections.Generic;

namespace RegentApi.Models
{
    public partial class User
    {
        public User()
        {
            UserClaims = new HashSet<UserClaim>();
            UserLogins = new HashSet<UserLogin>();
            Roles = new HashSet<Role>();
        }

        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; } = null!;

        public virtual ICollection<UserClaim> UserClaims { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
