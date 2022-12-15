using AutoMapper;
using BankApp.Application.DTOs;
using BankApp.Domain.Entities;

namespace BankApp.Api.Profiles
{
    public class BankTransactionProfile : Profile
    {
        public BankTransactionProfile()
        {
            CreateMap<BankTransaction, BankTransactionDto>().ReverseMap();
        }
    }
}
