using AutoMapper;
using BankApp.Application.DTOs;
using BankApp.Domain.Entities;

namespace BankApp.Api
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Account, AccountDto>();
                config.CreateMap<AccountDto, Account>();
            });
            return mappingConfig;
        }
    }
}
