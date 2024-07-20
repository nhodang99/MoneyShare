using Microsoft.AspNetCore.Mvc;
using MoneyShare.API.Services;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Interfaces;

namespace MoneyShare.API.Controllers
{
    [ApiController]
    public class BillsController : ControllerBase
    {
        public BillsService _service;

        public BillsController(BillsService service)
        {
            _service = service;
        }

        [Route("/bills")]
        [HttpGet]
        public IEnumerable<Bill> GetBills()
        {
            return _service.GetAllBills();
        }

        [Route("/bills/{id}")]
        [HttpGet]
        public Bill GetBillById(int id)
        {
            var bill = _service.GetBillById(id);
            if (bill == null)
            {
                return new Bill();
            }
            return bill;
        }

        [Route("/bills")]
        [HttpPost]
        public IActionResult Add(Bill bill)
        {
            if (bill == null)
            {
                return BadRequest("Bill invalid");
            }
            _service.AddBill(bill);
            return Ok(bill);
        }
    }
}
