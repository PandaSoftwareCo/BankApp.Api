using AutoMapper;
using BankApp.Application.DTOs;
using BankApp.Domain.Entities;

namespace BankApp.Api.Profiles
{
    public class BalanceProfile : Profile
    {
        public BalanceProfile()
        {
            CreateMap<Balance, BalanceDto>().ReverseMap();
        }
    }
}
