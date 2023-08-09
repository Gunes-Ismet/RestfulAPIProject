using AutoMapper;
using RestfulAPIProject.Models.DTO_s.AuthDTO;
using RestfulAPIProject.Models.DTO_s.CategoryDTO_s;
using RestfulAPIProject.Models.Entities.Concrete;

namespace RestfulAPIProject.Infrastructure.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Category,GetCategoryDTO>().ReverseMap();
            CreateMap<Category,CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<AppUser,AuthenticationDTO>().ReverseMap();
        }
    }
}
