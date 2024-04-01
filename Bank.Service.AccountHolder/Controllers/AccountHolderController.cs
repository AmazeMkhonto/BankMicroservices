using AutoMapper;
using Bank.Service.AccountHolder.Data;
using Bank.Service.AccountHolder.Models;
using Bank.Service.AccountHolder.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Service.AccountHolder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountHolderController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDTO _response;
        private IMapper _mapper;

        public AccountHolderController(AppDbContext db, IMapper mapper)
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
                IEnumerable<AccountHolders> objList = _db.AccountHolders.ToList();
                _response.Result = _mapper.Map<IEnumerable<AccountHolderDTO>>(objList);
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
                AccountHolders obj = _db.AccountHolders.First(u => u.Id == id);
                _response.Result = _mapper.Map<AccountHolderDTO>(obj);
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
        public ResponseDTO Post([FromBody] AccountHolderDTO dto)
        {
            try
            {
                AccountHolders obj = _mapper.Map<AccountHolders>(dto);
                _db.AccountHolders.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<AccountHolderDTO>(obj);
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
        public ResponseDTO Put([FromBody] AccountHolderDTO dto)
        {
            try
            {
                AccountHolders obj = _mapper.Map<AccountHolders>(dto);
                _db.AccountHolders.Update(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<AccountHolderDTO>(obj);
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
                AccountHolders obj = _db.AccountHolders.First(u => u.Id == id);
                _db.AccountHolders.Remove(obj);
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

