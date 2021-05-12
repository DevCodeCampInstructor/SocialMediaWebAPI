using Microsoft.EntityFrameworkCore;
using SocialMediaWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
    }
}
