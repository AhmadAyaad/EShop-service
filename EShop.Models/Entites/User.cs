using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EShop.Models.Entites
{
    public class User : IdentityUser
    {
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
