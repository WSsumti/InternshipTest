using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InternshipTest.MVC.Models;
using InternshipTest.MVC.Data;

namespace InternshipTest.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDataLayer _dataLayer;

    public HomeController(ILogger<HomeController> logger, IDataLayer dataLayer)
    {
        _logger = logger;
        _dataLayer = dataLayer;
    }

    public IActionResult Index()
    {
        return View(_dataLayer.GetAllSales());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public IActionResult Create()
    {
        return View();
    }
    public IActionResult Update(string id)
    {
        return View(_dataLayer.GetSaleByID(id));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Sale sale)
    {
        if (ModelState.IsValid)
        {
            _dataLayer.CreateSale(sale);
            _logger.LogInformation($"Sale number {sale.SalesOrder} was created");
            return RedirectToAction("Index");
        }
        return View(sale);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(Sale sale)
    {
        if (ModelState.IsValid)
        {
            _dataLayer.UpdateSale(sale);
            _logger.LogInformation($"Sale number {sale.SalesOrder} was modified");
            return RedirectToAction("Index");
        }
        return View(sale);
    }
    public IActionResult Delete(string id)
    {
        _dataLayer.DeleteSale(id);
        _logger.LogInformation($"Sale number {id} was deleted");
        return RedirectToAction("Index");
    }
}
