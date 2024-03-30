using Bank.Service.AccountHolder.Data;
using Bank.Service.AccountHolder.Models;
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

        public AccountHolderController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public object Get()
        {
            try
            {
                IEnumerable<AccountHolders> objList = _db.AccountHolders.ToList();
                return objList;
            }
            catch (Exception ex)
            {
            }
            return null;
        }


        [HttpGet]
        [Route("{id:int}")]
        public object Get(int id)
        {
            try
            {
                AccountHolders obj = _db.AccountHolders.First(u=>u.Id==id);
                return obj;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

    }
}
