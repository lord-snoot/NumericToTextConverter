using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using NumericToTextConverter.Service;

namespace NumericToTextConverter.Controllers;

public class ConverterController : Controller
{
    private readonly IConverterService _converterService;

    public ConverterController(IConverterService converterService)
    {
        _converterService = converterService;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public string Convert(string input)
    {
        return HtmlEncoder.Default.Encode(_converterService.Convert(input));
    }
}