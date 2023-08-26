using Core.Entities;
using Core.Infraestructure;
using Core.Services.Interfaces;

namespace Core.Services.Imp
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICustomerRepository _customerRepository;

        public PostService(IPostRepository postRepository, ICustomerRepository customerRepository)
        {
            _postRepository = postRepository;
            _customerRepository = customerRepository;
        }

        public void CreatePost(Post post)
        {
            var customers = _customerRepository.GetAll().Where(x => x.Id == post.CustomerId);

            if(customers.Any())
            {
                if (post.Body?.Length > 97)
                {
                    var text = post.Body.Remove(97);
                    var textRemove = text.Insert(97, "...");
                    post.Body = textRemove;
                }

                if (post.Type == 1)
                {
                    post.Category = "Farándula";
                }
                else if (post.Type == 2)
                {
                    post.Category = "Política";
                }
                else if (post.Type == 3)
                {
                    post.Category = "Fútbol";
                }

                _postRepository.CreatePost(post);
            }
        }
    }
}
