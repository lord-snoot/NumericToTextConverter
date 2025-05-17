using Microsoft.AspNetCore.Mvc;

namespace NumericToTextConverter.Controllers;

public class ConverterController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Convert()
    {
        return View();
    }
}