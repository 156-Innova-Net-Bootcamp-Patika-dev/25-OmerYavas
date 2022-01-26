using AutoMapper;
using PatikaOdev3.Model.DTOs.ArticleDTOs;
using PatikaOdev3.Model.DTOs.CategoryDTOs;
using PatikaOdev3.Model.DTOs.CommentDTOs;
using PatikaOdev3.Model.DTOs.RoleAddDTOs;
using PatikaOdev3.Model.DTOs.UserDTOs;
using PatikaOdev3.Model.Entities;

namespace PatikaOdev3.Business.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {

        //Entity ve DTO'lar arasında otomatik dönüşme işlemlerini yapar.
        public MapProfile()
        {
            #region CategoryMapper
            CreateMap<CategoryAddDTO, Category>();
            CreateMap<Category, CategoryAddDTO>();

            CreateMap<CategoryListDTO, Category>();
            CreateMap<Category, CategoryListDTO>();

            CreateMap<CategoryUpdateDTO, Category>();
            CreateMap<Category, CategoryUpdateDTO>();
            #endregion


            #region ArticleMapper
            CreateMap<ArticleAddDTO, Article>();
            CreateMap<Article, ArticleAddDTO>();

            CreateMap<ArticleListDTO, Article>();
            CreateMap<Article, ArticleListDTO>()
                .ForMember(dto => dto.CategoryName,
                (System.Action<IMemberConfigurationExpression<Article, ArticleListDTO, string>>)(                map => map.MapFrom((System.Linq.Expressions.Expression<System.Func<Article, string>>)(entity => (string)entity.Category.Name))));
            CreateMap<ArticleUpdateDTO, Article>();
            CreateMap<Article, ArticleUpdateDTO>();
            #endregion


            #region CommentMapper
            CreateMap<CommentAddDTO, Comment>();
            CreateMap<Comment, CommentAddDTO>();

            CreateMap<CommentListDTO, Comment>();
            CreateMap<Comment, CommentListDTO>()
                .ForMember(dto => dto.ArticleTitle,
                map => map.MapFrom(entity => entity.Article.Title));

            CreateMap<CommentUpdateDTO, Comment>();
            CreateMap<Comment, CommentUpdateDTO>();
            #endregion

            #region UserMapper
            CreateMap<UserAddDTO, User>();
            CreateMap<User, UserAddDTO>();

            CreateMap<UserListDTO, User>();
            CreateMap<User, UserListDTO>()
                .ForMember(dto => dto.Role,
                map => map.MapFrom(entity => entity.Role.Name))
                .ForMember(dto => dto.Gender,
                map => map.MapFrom(entity => entity.Gender.GenderName));

            CreateMap<UserUpdateDTO, User>();
            CreateMap<User, UserUpdateDTO>();
            #endregion

            #region UserMapper
            CreateMap<RoleAddDTO, Role>();
            CreateMap<Role, RoleAddDTO>();

            CreateMap<RoleListDTO, Role>();
            CreateMap<Role, RoleListDTO>();

            CreateMap<RoleUpdateDTO, Role>();
            CreateMap<Role, RoleUpdateDTO>();
            #endregion


        }
    }
}
