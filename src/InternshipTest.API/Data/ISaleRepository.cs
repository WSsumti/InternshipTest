using InternshipTest.API.Models;

namespace InternshipTest.API.Data
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAllSales();
        void CreateSale(Sale sale);
        void UpdateSale(Sale sale);
        Sale GetSaleByID(string salesOrder);
        void DeleteSale(string salesOrder);
    }
}
