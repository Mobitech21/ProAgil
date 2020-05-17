using Microsoft.AspNetCore.Identity;
using ProAgil.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProAgil.Domain.Entidades
{
   public class UserRole : IdentityUserRole<int>
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
