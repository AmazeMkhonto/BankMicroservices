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



        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountDTO model)
        {
            if (ModelState.IsValid)
            {
                ResponseDTO? response = await _accountService.CreateAccountAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Account created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(long id)
        {
            ResponseDTO? response = await _accountService.GetAccountByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                ResponseDTO? model = JsonConvert.DeserializeObject<ResponseDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CouponDelete(AccountDTO accountDto)
        {
            ResponseDTO? response = await _accountService.DeleteAccountAsync(accountDto.Id);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Coupon deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(accountDto);
        }
    }
}
