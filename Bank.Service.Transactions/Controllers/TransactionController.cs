using AutoMapper;
using Bank.Service.Transactions.Data;
using Bank.Service.Transactions.Models;
using Bank.Service.Transactions.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;

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

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDTO Get(int id)
        {
            try
            {
                Transactionss obj = _db.Transactions.First(u => u.Id == id);
                _response.Result = _mapper.Map<TransactionDTO>(obj);
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByAcc/{AccountNumber}")]
        public ResponseDTO GetByUser(long accountId)
        {
            try
            {
                Transactionss obj = _db.Transactions.First(u => u.BankAccountId == accountId);
                _response.Result = _mapper.Map<TransactionDTO>(obj);
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpPost]
        public ResponseDTO Post([FromBody] TransactionDTO dto)
        {
            try
            {
                Transactionss obj = _mapper.Map<Transactionss>(dto);
                _db.Transactions.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<TransactionDTO>(obj);
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDTO Delete(int id)
        {
            try
            {
                Transactionss obj = _db.Transactions.First(u => u.Id == id);
                _db.Transactions.Remove(obj);
                _db.SaveChanges();

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
