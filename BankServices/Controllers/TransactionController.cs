using BankServices.Models;
using BankServices.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BankServices.Controllers
{
	public class TransactionController : Controller
	{
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }


        public async Task<IActionResult> Index()
        {
            List<TransactionDTO>? list = new();

            ResponseDTO? response = await _transactionService.GetAllTransactionsAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<TransactionDTO>>(Convert.ToString(response.Result));
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
        public async Task<IActionResult> Create(TransactionDTO model)
        {
            if (ModelState.IsValid)
            {
                ResponseDTO? response = await _transactionService.CreateTransactionAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Transaction created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ResponseDTO? response = await _transactionService.GetTransactionByIdAsync(id);

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
        public async Task<IActionResult> CouponDelete(TransactionDTO transactionDto)
        {
            ResponseDTO? response = await _transactionService.DeleteTransactionAsync(transactionDto.Id);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Transaction deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(transactionDto);
        }
    }
}
