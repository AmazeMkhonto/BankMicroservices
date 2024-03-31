using AutoMapper;
using Bank.Service.Transactions.Models;
using Bank.Service.Transactions.Models.DTO;

namespace Bank.Service.Transactions
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<TransactionDTO, Transactionss>();
                config.CreateMap<Transactionss, TransactionDTO>();
            });
            return mappingConfig;
        }
    }
}
