using Core.Entities;
using Core.Infraestructure;
using Infraestructure.Data;

namespace Infraestructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository (AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetAllPost()
        {
            return _context.Posts.AsQueryable();
        }

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }
        
        public void DeletePost(IEnumerable<Post> posts)
        {
            _context.Posts.RemoveRange(posts);
            _context.SaveChanges();
        }
    }
}
