using AutoMapper;
using ProjekatNaVezbama.DTO;
using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.Mapping
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<User, UserOutDTO>().ReverseMap();

            CreateMap<Post, PostCreateDTO>()
                .ForMember(postDTO => postDTO.CreatorUsername, post => post.MapFrom(p => p.Creator.Username))
                .ReverseMap();
            CreateMap<Post, PostOutDTO>()
                .ForMember(postDTO => postDTO.CreatorUsername, post => post.MapFrom(p => p.Creator.Username))
                .ReverseMap();

            CreateMap<Comment, CommentCreateDTO>()
                .ForMember(commentDTO => commentDTO.CreatorUsername, comment => comment.MapFrom(c => c.Creator.Username))
                .ForMember(commentDTO => commentDTO.PostID, comment => comment.MapFrom(p => p.OriginPostID))
                .ReverseMap();
            CreateMap<Comment, CommentOutDTO>()
                .ForMember(commentDTO => commentDTO.CreatorUsername, comment => comment.MapFrom(c => c.Creator.Username))
                .ForMember(commentDTO => commentDTO.PostID, comment => comment.MapFrom(p => p.OriginPostID))
                .ReverseMap();
        }

    }
}
