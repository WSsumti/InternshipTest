using InternshipTest.MVC.Models;

namespace InternshipTest.MVC.Data
{
    public interface IDataLayer
    {
        IEnumerable<Sale> GetAllSales();
        void CreateSale(Sale sale);
        void UpdateSale(Sale sale);
        Sale GetSaleByID(string salesOrder);
        void DeleteSale(string salesOrder);
    }
}
