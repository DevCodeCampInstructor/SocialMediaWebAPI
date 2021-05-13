﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaWebAPI.Data;
using SocialMediaWebAPI.Models;
using System;
using System.Linq;

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
        [HttpGet, Authorize]
        public IActionResult GetPostsForUser(string userId)
        {
            var userFrom = this.HttpContext.User;
            var user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            if(user == null)
            {
                return NotFound();
            }
            var posts = _context.Posts.Where(p => p.UserId == user.Id);
            return Ok(posts);
        }

        [HttpGet("{id}", Name = "GetPostForUser")]
        public IActionResult GetPostForUser(string userId, int id)
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
        public IActionResult CreatePostForUser(string userId, [FromBody] Post post)
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
        public IActionResult UpdatePostForUser(string userId, int id, [FromBody] Post post)
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
        public IActionResult DeletePostForUser(string userId, int id)
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

