using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using NumericToTextConverter.Models.Constants;

namespace NumericToTextConverter.Controllers;

public class ConverterController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public string Convert(int input)
    {
        return HtmlEncoder.Default.Encode(NumericTextConstants.Ones[input]);
    }
}