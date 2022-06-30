using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdentityExampleV1.Data
{
    /// <summary>
    /// IdentityDbContext contains all the user tables 
    /// </summary>
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions) : 
                base(dbContextOptions) 
        {
            
        }
    }
}
