using AutoMapper;
using ProjekatNaVezbama.DTO;
using ProjekatNaVezbama.Model;
using ProjekatNaVezbama.Repositories;

namespace ProjekatNaVezbama.Services
{
    public class PostService : IPostService
    {

        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository pr, IMapper map)
        {
            _postRepository = pr;
            _mapper = map;
        }

        public async Task<PostOutDTO> CreatePost(PostCreateDTO postDTO)
        {
            //check for username
            if(await _postRepository.CheckIfUserExists(postDTO.CreatorUsername))
            {

                var post = _mapper.Map<Post>(postDTO);
                var retVal = await _postRepository.CreatePost(post);

                return _mapper.Map<PostOutDTO>(retVal);
            }
            //user doesn't exist
            return null;
        }

        public async Task<bool> DeletePost(int id)
        {

            var tempPost = await _postRepository.GetPost(id);
            var retVal = false;
            if (tempPost != null)
            {
                await _postRepository.DeletePost(tempPost);
                retVal = true;
            }


            return retVal;
        }

        public async Task<IEnumerable<PostOutDTO>> GetAllPosts()
        {
           var retVal = await _postRepository.GetAllPosts();
           return _mapper.Map<IEnumerable<PostOutDTO>>(retVal);
        }

        public async Task<PostOutDTO> GetPost(int postID)
        {
            //check if user is available??
            var tempPost = await _postRepository.GetPost(postID);

            if (tempPost == null)
            {
                return null;
            }

            return _mapper.Map<PostOutDTO>(tempPost);
        }
    }
}
