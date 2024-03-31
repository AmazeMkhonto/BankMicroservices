using AutoMapper;
using Bank.Service.Account.Models;
using Bank.Service.Account.Models.DTO;

namespace Bank.Service.Account
{
        public class MappingConfig
        {
            public static MapperConfiguration RegisterMaps()
            {
                var mappingConfig = new MapperConfiguration(config =>
                {
                    config.CreateMap<AccountDTO, Accounts>();
                    config.CreateMap<Accounts, AccountDTO>();
                });
                return mappingConfig;
            }
        }
}
