using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaWebAPI.Data;
using SocialMediaWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaWebAPI.Controllers
{
    [Route("api/users/{userId}/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetPostsForUser(int userId)
        {
            var user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            if(user == null)
            {
                return NotFound();
            }
            var posts = _context.Posts.Where(p => p.UserId == user.Id);
            return Ok(posts);
        }

        [HttpGet("{id}", Name = "GetPostForUser")]
        public IActionResult GetPostForUser(int userId, int id)
        {
            var user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            var post = _context.Posts.Where(p => p.UserId == user.Id && p.Id == id).SingleOrDefault();
            if(post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost]
        public IActionResult CreatePostForUser(int userId, [FromBody] Post post)
        {
            var user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            post.UserId = user.Id;
            post.PostDate = DateTime.Now;
            _context.Posts.Add(post);
            _context.SaveChanges();
            return CreatedAtRoute("GetPostForUser", new { userId, id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePostForUser(int userId, int id, [FromBody] Post post)
        {
            var user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            var postEntity = _context.Posts.Where(p => p.Id == id).SingleOrDefault();
            if(postEntity == null)
            {
                return NotFound();
            }
            postEntity.Title = post.Title;
            postEntity.Content = post.Content;
            _context.Posts.Update(postEntity);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePostForUser(int userId, int id)
        {
            var user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            var post = _context.Posts.Where(p => p.Id == id).SingleOrDefault();
            if(post == null)
            {
                return NotFound();
            }
            _context.Posts.Remove(post);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

