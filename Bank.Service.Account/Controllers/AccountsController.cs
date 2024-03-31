using AutoMapper;
using Bank.Service.Account.Data;
using Bank.Service.Account.Models;
using Bank.Service.Account.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;

namespace Bank.Service.Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly AccountDbContext _db;
        private ResponseDTO _response;
        private IMapper _mapper;

        public AccountsController(AccountDbContext db, IMapper mapper)
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
                IEnumerable<Accounts> objList = _db.Accounts.ToList();
                _response.Result = _mapper.Map<IEnumerable<AccountDTO>>(objList);
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
        [Route("{AccountNumber:long}")]
        public ResponseDTO Get(long id)
        {
            try
            {
                Accounts obj = _db.Accounts.First(u => u.Id == id);
                _response.Result = _mapper.Map<AccountDTO>(obj);
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
        [Route("GetByUser/{AccountHolderId}")]
        public ResponseDTO GetByUser(int accountHolderId)
        {
            try
            {
                List<Accounts> accounts = _db.Accounts.Where(u => u.AccountHolderId == accountHolderId).ToList();
                if (accounts.Count == 0)
                {
                    _response.Message = "No accounts found for this user.";
                }
                else
                {
                    List<AccountDTO> accountDtos = _mapper.Map<List<AccountDTO>>(accounts);
                    _response.Result = accountDtos;
                }
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
        public ResponseDTO Post([FromBody] AccountDTO dto)
        {
            try
            {
                Accounts obj = _mapper.Map<Accounts>(dto);
                _db.Accounts.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<AccountDTO>(obj);
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpPut]
        public ResponseDTO Put([FromBody] AccountDTO dto)
        {
            try
            {
                Accounts obj = _mapper.Map<Accounts>(dto);
                _db.Accounts.Update(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<AccountDTO>(obj);
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
        [Route("{id:long}")]
        public ResponseDTO Delete(long id)
        {
            try
            {
                Accounts obj = _db.Accounts.First(u => u.Id == id);
                _db.Accounts.Remove(obj);
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
