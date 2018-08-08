using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Identity.Domain
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
