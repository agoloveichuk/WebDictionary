using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public List<Dictionary>? Dictionaries { get; set; }
    }
}
