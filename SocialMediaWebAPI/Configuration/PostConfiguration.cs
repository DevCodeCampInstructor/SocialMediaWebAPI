using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMediaWebAPI.Models;
using System;

namespace SocialMediaWebAPI.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData
            (
                new Post
                {
                    Id = 1,
                    Title = "Look what I found!",
                    Content = "I found a buffalo nickel!",
                    Likes = 0,
                    PostDate = DateTime.Now
                },
                new Post
                {
                    Id = 2,
                    Title = "Whats your favorite movie?",
                    Content = "Mine is Groundhog Day",
                    Likes = 0,
                    PostDate = DateTime.Now
                }
            );
        }
    }
}
