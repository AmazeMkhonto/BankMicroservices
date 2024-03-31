using AutoMapper;
using Bank.Service.Transactions.Data;
using Bank.Service.Transactions.Models;
using Bank.Service.Transactions.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Service.Transactions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionDbContext _db;
        private ResponseDTO _response;
        private IMapper _mapper;

        public TransactionController(TransactionDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDTO();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<Transactionss> objList = _db.Transactions.ToList();
                _response.Result = _mapper.Map<IEnumerable<TransactionDTO>>(objList);
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
