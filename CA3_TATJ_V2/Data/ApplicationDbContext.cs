using System;
using System.Collections.Generic;
using System.Text;
using CA3_TATJ_V2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CA3_TATJ_V2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}
