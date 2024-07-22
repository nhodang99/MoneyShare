using Microsoft.AspNetCore.Mvc;
using MoneyShare.API.Services;
using MoneyShare.Domain.Bills;

namespace MoneyShare.API.Controllers
{
    [ApiController]
    [Route("/bills")]
    public class BillsController : ControllerBase
    {
        private readonly BillsService _service;

        public BillsController(BillsService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Bill> GetBills()
        {
            return _service.GetAll();
        }

        [Route("{id}")]
        [HttpGet]
        public Bill GetBillById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public IActionResult Add(Bill bill)
        {
            if (bill == null)
            {
                return BadRequest(bill);
            }
            _service.Add(bill);
            return Ok(bill);
        }

        [Route("edit/{id}")]
        [HttpPost]
        public IActionResult Edit(int id, Bill bill)
        {
            if (bill == null || id != bill.Id)
            {
                return BadRequest(bill);
            }
            _service.Update(id, bill);
            return Ok(bill);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var bill = _service.GetById(id);
            if (bill != null)
            {
                _service.DeleteById(id);
                return Ok(bill);
            }
            return NotFound();
        }

        [Route("group/{groupId}")]
        [HttpGet]
        public IEnumerable<Bill> GetBillsInGroup(int groupId)
        {
            return _service.GetBillsInGroup(groupId);
        }

        [Route("user/{userId}")]
        [HttpGet]
        public IEnumerable<Bill> GetBillsByUser(int userId)
        {
            return _service.GetBillsByUser(userId);
        }

        [Route("delete/group/{groupId}")]
        [HttpPost]
        public IActionResult DeleteBillsInGroup(int groupId)
        {
            _service.DeleteBillsInGroup(groupId);
            return Ok();
        }
    }
}
