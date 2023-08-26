using Core.Entities;

namespace Core.Infraestructure
{
    public interface IPostRepository
    {
        void CreatePost(Post post);
        IEnumerable<Post> GetAllPost();
        void DeletePost(IEnumerable<Post> posts);
    }
}
