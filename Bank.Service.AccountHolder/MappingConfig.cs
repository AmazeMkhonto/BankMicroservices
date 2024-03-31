using AutoMapper;
using Bank.Service.AccountHolder.Models;
using Bank.Service.AccountHolder.Models.DTO;

namespace Bank.Service.AccountHolder
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AccountHolderDTO, AccountHolders>();
                config.CreateMap<AccountHolders, AccountHolderDTO>();
            });
            return mappingConfig;
        }
    }
}
