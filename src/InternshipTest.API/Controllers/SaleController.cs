using InternshipTest.API.Data;
using InternshipTest.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternshipTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;
        public SaleController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Sale>> GetAllSales()
        {
            return Ok(_saleRepository.GetAllSales());
        }
        [HttpGet("{id}")]
        public ActionResult<Sale> GetSaleByID(string id)
        {
            return Ok(_saleRepository.GetSaleByID(id));
        }
        [HttpPost]
        public ActionResult<Sale> CreateSale(Sale sale)
        {
            _saleRepository.CreateSale(sale);
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult<Sale> UpdateSale(string id, Sale sale)
        {
            var temp = _saleRepository.GetSaleByID(id);
            if (temp != null)
            {
                _saleRepository.UpdateSale(sale);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Sale> DeleteSale(string id)
        {
            var sale = _saleRepository.GetSaleByID(id);
            if (sale != null)
            {
                _saleRepository.DeleteSale(id);
                return Ok();
            }
            return NotFound();
        }


    }
}
