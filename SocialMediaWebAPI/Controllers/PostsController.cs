using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaWebAPI.Data;
using SocialMediaWebAPI.Models;
using System;
using System.Linq;
using System.Security.Claims;

namespace SocialMediaWebAPI.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet, Authorize]
        public IActionResult GetPostsForUser()
        {
            var user = _context.Users.Where(u => u.UserName == User.FindFirstValue(ClaimTypes.Name)).SingleOrDefault();
            if(user == null)
            {
                return NotFound();
            }
            var posts = _context.Posts.Where(p => p.UserId == user.Id);
            return Ok(posts);
        }

        [HttpGet("{id}"), Authorize]
        public IActionResult GetPostForUser(int id)
        {
            var user = _context.Users.Where(u => u.UserName == User.FindFirstValue(ClaimTypes.Name)).SingleOrDefault();
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

        [HttpPost, Authorize]
        public IActionResult CreatePostForUser(string userId, [FromBody] Post post)
        {
            var user = _context.Users.Where(u => u.UserName == User.FindFirstValue(ClaimTypes.Name)).SingleOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            post.UserId = user.Id;
            post.PostDate = DateTime.Now;
            _context.Posts.Add(post);
            _context.SaveChanges();
            return StatusCode(201, post);
        }

        [HttpPut("{id}"), Authorize]
        public IActionResult UpdatePostForUser(string userId, int id, [FromBody] Post post)
        {
            var user = _context.Users.Where(u => u.UserName == User.FindFirstValue(ClaimTypes.Name)).SingleOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            var postEntity = _context.Posts.Where(p => p.UserId == user.Id && p.Id == id).SingleOrDefault();
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

        [HttpDelete("{id}"), Authorize]
        public IActionResult DeletePostForUser(string userId, int id)
        {
            var user = _context.Users.Where(u => u.UserName == User.FindFirstValue(ClaimTypes.Name)).SingleOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            var post = _context.Posts.Where(p => p.UserId == user.Id && p.Id == id).SingleOrDefault();
            if(post == null)
            {
                return NotFound();
            }
            _context.Posts.Remove(post);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpGet("{id}/likes/{likesAmount}"), Authorize]
        public IActionResult UpdatePostLikes(int id, int likesAmount)
        {
            var user = _context.Users.Where(u => u.UserName == User.FindFirstValue(ClaimTypes.Name)).SingleOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            var post = _context.Posts.Where(p => p.UserId == user.Id && p.Id == id).SingleOrDefault();
            if (post == null)
            {
                return NotFound();
            }
            post.Likes += likesAmount;
            _context.Posts.Update(post);
            _context.SaveChanges();
            return Ok(post);
        }
    }
}

