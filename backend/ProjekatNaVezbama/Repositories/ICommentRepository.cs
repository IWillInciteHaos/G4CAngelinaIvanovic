﻿using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.Repositories
{
    public interface ICommentRepository
    {

        public Task<Comment> CreateComment(Comment comment);
        public Task<bool> CheckIfUserExists(string username);
        public Task<bool> CheckIfPostExists(int postID);
        public Task<IEnumerable<Comment>> GetAllComments();
        public Task<List<Comment>> GetPostComments(Post p);
        public Task<Comment> GetComment(int commentID);
        public Task DeleteComment(Comment comment);
        public Task DeleteMultipleComments(List<Comment> comments);
        /*
        bool DeleteComment(Comment c);
        bool UpdateComment(string content, int ID);
        Post GetComment(int id);
        List<Post> GetAllComments();
        */
    }
}
