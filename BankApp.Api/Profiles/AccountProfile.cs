using AutoMapper;
using BankApp.Application.DTOs;
using BankApp.Domain.Entities;

namespace BankApp.Api.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
        }
    }
}
