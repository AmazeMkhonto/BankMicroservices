using BankServices.Models;
using BankServices.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BankServices.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        public async Task<IActionResult> Index()
        {
            List<AccountDTO>? list = new();

            ResponseDTO? response = await _accountService.GetAllAccountsAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<AccountDTO>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }
    }
}
