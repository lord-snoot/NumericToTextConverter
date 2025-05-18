using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using NumericToTextConverter.Models;
using NumericToTextConverter.Service;

namespace NumericToTextConverter.Controllers;

public class ConverterController : Controller
{
    private readonly IConverterService _converterService;
    
    public ConverterController(IConverterService converterService)
    {
        _converterService = converterService;
    }
    
    public IActionResult Index(string input)
    {
        ViewData["output"] = HtmlEncoder.Default.Encode(_converterService.Convert(input));
        return View();
    }
}