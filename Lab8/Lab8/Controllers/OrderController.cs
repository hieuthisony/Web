using Lab8.Models;
using Lab8.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab8.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;

        // Inject cả OrderService và CustomerService
        public OrderController(IOrderService orderService, ICustomerService customerService)
        {
            _orderService = orderService;
            _customerService = customerService;
        }

        // GET: /Order
        public IActionResult Index()
        {
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }

        // GET: /Order/Create
        public IActionResult Create()
        {
            // Lấy danh sách khách hàng để hiển thị Dropdown chọn người mua
            ViewBag.Customers = _customerService.GetAllCustomers();
            return View();
        }

        // POST: /Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            // Kiểm tra tính hợp lệ
            if (!ModelState.IsValid)
            {
                // Nếu lỗi, load lại danh sách khách hàng
                ViewBag.Customers = _customerService.GetAllCustomers();
                return View(order);
            }

            _orderService.CreateOrder(order);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Order/Delete/5
        public IActionResult Delete(int id)
        {
            _orderService.DeleteOrder(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
