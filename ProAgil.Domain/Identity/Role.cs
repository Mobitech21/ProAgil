using Microsoft.AspNetCore.Identity;
using ProAgil.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProAgil.Domain.Identity
{  /// <summary>
   ///  role papeis
   /// </summary>
    public class Role : IdentityRole<int>
    {
        // role sao papeias do usuarios n pra n
        public List<UserRole> UserRoles { get; set; }

    }
}
