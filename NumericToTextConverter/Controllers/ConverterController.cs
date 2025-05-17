using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace NumericToTextConverter.Controllers;

public class ConverterController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public string Convert(string input)
    {
        return HtmlEncoder.Default.Encode(input);
    }
}