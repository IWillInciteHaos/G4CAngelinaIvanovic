using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjekatNaVezbama.DTO;
using ProjekatNaVezbama.Model;
using ProjekatNaVezbama.Repositories;

namespace ProjekatNaVezbama.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentService, IMapper map)
        {
            _commentRepository = commentService;
            _mapper = map;
        }

        public async Task<CommentOutDTO> CreateComment(CommentCreateDTO commentDTO)
        {
            var retVal = new CommentOutDTO();
            //check for username
            if (await _commentRepository.CheckIfUserExists(commentDTO.CreatorUsername))
            {
                if (await _commentRepository.CheckIfPostExists(commentDTO.PostID))
                {
                    var comment = await _commentRepository.CreateComment(_mapper.Map<Comment>(commentDTO));
                    return _mapper.Map<CommentOutDTO>(comment);
                }
                //forbid minus numbers to be used as the only part of the username?
                retVal.PostID = -1;
            }
            else
            {
                retVal.CreatorUsername = "-1";
            }
            //user doesn't exist
                
             
            return retVal;

        }

        public async Task<bool> DeleteComment(int commentID)
        {
            var tempComment = await _commentRepository.GetComment(commentID);
            var retVal = false;
            if (tempComment != null)
            {
                await _commentRepository.DeleteComment(tempComment);
                retVal = true;
            }


            return retVal;
        }

        public async Task<IEnumerable<CommentOutDTO>> GetAllComments()
        {
            var retVal = await _commentRepository.GetAllComments();
            return _mapper.Map<IEnumerable<CommentOutDTO>>(retVal);
        }

        public async Task<CommentOutDTO> GetComment(int commentID)
        {
            //check all users, check if there is the post        

            var tempComment = await _commentRepository.GetComment(commentID);
            //var userExists = _commentRepository.UserExists(tempComment.CreatorID);
            //var postExists = _commentRepository.PostExists(tempComment.OriginPostID);

            if (tempComment == null)
            {
                return null;
            }

            return _mapper.Map<CommentOutDTO>(tempComment);
        }
            


    }
}
