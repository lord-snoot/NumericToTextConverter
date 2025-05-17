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

    public string Convert(string input)
    {
        List<string> inputGroups = new List<string>();
        for (int i = input.Length; i > 0; i-= NumericTextConstants.GroupSize)
        {
            if (i > NumericTextConstants.GroupSize)
            {
                inputGroups.Add(input.Substring(
                    i - NumericTextConstants.GroupSize, 
                    NumericTextConstants.GroupSize)
                );
            }
            else
            {
                inputGroups.Add(input.Substring(0, i));
            }
        }

        inputGroups.Reverse();
        return HtmlEncoder.Default.Encode(String.Join(",", inputGroups));
    }
}