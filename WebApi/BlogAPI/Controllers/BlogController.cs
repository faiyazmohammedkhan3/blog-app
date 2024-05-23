using Microsoft.AspNetCore.Mvc;
using BlogAPI.Data;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly BlogRepository _blogRepository;

        public BlogController(BlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [HttpGet]
        public IActionResult GetAllBlogs()
        {
            var blogs = _blogRepository.GetAllBlogs();
            return Ok(blogs);
        }
    }
}

