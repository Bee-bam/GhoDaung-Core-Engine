using Microsoft.AspNetCore.Mvc;
using Gho_Daung___Order___Inventory_System__.Services;
using Microsoft.Identity.Client;
using Gho_Daung___Order___Inventory_System__.Enums;
using System.Reflection.Metadata.Ecma335;

namespace Gho_Daung___Order___Inventory_System__.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderservice)
        {
            _orderService = orderservice;
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(int productId, int quantity)
        {
            if (productId <= 0 || quantity <= 0)
            {
                TempData["ErrorMessage"] = "Invalid Input";
                return RedirectToAction("Index", "Home");
            }
            OrderResult result = await _orderService.PlaceOrderAsync(productId, quantity);

            switch (result)
            {
                case OrderResult.Success:
                    TempData["SuccessMessage"] = "Order Completed. Stock alocated successfully.";
                    return RedirectToAction("OrderSuccess");

                case OrderResult.ProductNotFound:
                    TempData["ErrorMessage"] = "Product Not Found!!";
                    return RedirectToAction("Index", "Home");

                case OrderResult.OutofStock:
                    TempData["ErrorMessage"] = "Sorry,We don't have Enough Items!!";
                    return RedirectToAction("Index", "Home");

                case OrderResult.ConcurrencyError:
                    TempData["ErrorMessage"] = "Someone else bought it a millisecond before you, please try clicking buy again!";
                    return RedirectToAction("Index", "Home");

                case OrderResult.UnknownError:
                    TempData["ErrorMessage"] = "Unknown Error Was Found !";
                    return RedirectToAction("Index", "Home");

                default:
                    TempData["ErrorMessage"] = "Unexpected Error Occurred!!";
                    return RedirectToAction("Index", "Home");
            }
        }
            public IActionResult OrderSuccess()
            {
                return View();
            }
    }
}
