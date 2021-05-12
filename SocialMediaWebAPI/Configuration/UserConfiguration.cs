using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMediaWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaWebAPI.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
            (
                new User
                {
                    Id = "36278af4-5e10-4afb-8651-182cbb49cd04",
                    FirstName = "David",
                    LastName = "Lagrange"
                },
                new User
                {
                    Id = "59944b4b-72e5-4329-9f8a-72eff632635d",
                    FirstName = "Michael",
                    LastName = "Terrill"
                }
            );
        }
    }
}
