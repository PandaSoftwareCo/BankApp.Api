using AutoMapper;
using BankApp.Application.DTOs;
using BankApp.Domain.Entities;

namespace BankApp.Api.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
