using Gho_Daung___Order___Inventory_System__.Data;
using Gho_Daung___Order___Inventory_System__.Enums;
using Gho_Daung___Order___Inventory_System__.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Reflection.Metadata.Ecma335;

namespace Gho_Daung___Order___Inventory_System__.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly OrderService _orderService;

        public OrderController(ApplicationDbContext context,OrderService orderservice)
        {
            _context = context;
            _orderService = orderservice;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _context.Products.Include(p => p.Inventory).ToListAsync();
            return View("~/Views/Home/Index.cshtml",items);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(int productId, int quantity)
        {
            if (productId <= 0 || quantity <= 0)
            {
                TempData["ErrorMessage"] = "Invalid Input";
                return RedirectToAction("Order", "Home");
            }
            OrderResult result = await _orderService.PlaceOrderAsync(productId, quantity);

            switch (result)
            {
                case OrderResult.Success:
                    TempData["SuccessMessage"] = "Order Completed. Stock alocated successfully.";
                    return RedirectToAction("OrderSuccess");

                case OrderResult.ProductNotFound:
                    TempData["ErrorMessage"] = "Product Not Found!!";
                    return RedirectToAction("Index");

                case OrderResult.OutofStock:
                    TempData["ErrorMessage"] = "Sorry,We don't have Enough Items!!";
                    return RedirectToAction("Index");

                case OrderResult.ConcurrencyError:
                    TempData["ErrorMessage"] = "Someone else bought it a millisecond before you, please try clicking buy again!";
                    return RedirectToAction("Index");

                case OrderResult.UnknownError:
                    TempData["ErrorMessage"] = "Unknown Error Was Found !";
                    return RedirectToAction("Index");

                default:
                    TempData["ErrorMessage"] = "Unexpected Error Occurred!!";
                    return RedirectToAction("Index");
            }
        }
            public IActionResult OrderSuccess()
            {
                return View("~/Views/Home/OrderSuccess.cshtml");
            }
    }
}
