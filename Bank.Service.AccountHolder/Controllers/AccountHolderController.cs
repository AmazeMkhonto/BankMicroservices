using Azure;
using Bank.Service.AccountHolder.Data;
using Bank.Service.AccountHolder.Models;
using Bank.Service.AccountHolder.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Bank.Service.AccountHolder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountHolderController : ControllerBase
    {
        private readonly AppDbContext _db;

        private ResponseDTO _responseDTO;

        public AccountHolderController(AppDbContext db)
        {
            _db = db;
            _responseDTO = new ResponseDTO();
        }

        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<AccountHolders> objList = _db.AccountHolders.ToList();
                return (ResponseDTO)(_responseDTO.Result = objList);
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;
        }


        [HttpGet]
        [Route("{id:int}")]
        public ResponseDTO Get(int id)
        {
            try
            {
                AccountHolders obj = _db.AccountHolders.First(u=>u.Id==id);
                return (ResponseDTO)(_responseDTO.Result = obj);
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;
        }

    }
}
