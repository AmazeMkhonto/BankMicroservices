﻿using Microsoft.AspNetCore.Mvc;

namespace BankServices.Controllers
{
	public class TransactionController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
