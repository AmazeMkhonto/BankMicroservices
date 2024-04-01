using BankServices.Models;
using BankServices.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BankServices.Controllers
{
    public class AccountHolderController : Controller
    {
        private readonly IAccountHolderService _accountHolderService;
        public AccountHolderController(IAccountHolderService accountHolderService)
        {
            _accountHolderService = accountHolderService;
        }


        public async Task<IActionResult> Index()
        {
            List<AccountHolderDTO>? list = new();

            ResponseDTO? response = await _accountHolderService.GetAllAccountHoldersAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<AccountHolderDTO>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }
    }
}
