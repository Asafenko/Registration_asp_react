using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Registration_asp_react.Controllers;

[ApiController]
[Route("[controller]")]
public class TradeMarkController : ControllerBase
{
    private static readonly List<string> ListTradeMark=new();
    private readonly ILogger<TradeMarkController> _logger;

    public TradeMarkController(ILogger<TradeMarkController> logger)
    {
        _logger = logger;
    }

    // private static readonly List<string> AlreadyChecked =
    //     ListTradeMark.ConvertAll((input => RemoveStringReader(input).ToLower()));

    private static string RemoveStringReader(string input)
    {
        var s = new StringBuilder(input.Length); // (input.Length);
        using (var reader = new StringReader(input))
        {
            for (var i = 0; i < input.Length; i++)
            {
                var c = (char)reader.Read();
                if (!char.IsWhiteSpace(c))
                {
                    s.Append(c);
                }
            }
        }

        return s.ToString();
    }

    
    
    
    [HttpGet("registration")]
    public Task<IActionResult> Registration(string name)
    {
        var newName = RemoveStringReader(name);
        foreach (var item in ListTradeMark)
        {
            if (string.Equals(newName, RemoveStringReader(item), StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult<IActionResult>(BadRequest(new { message = "Error" }));
            }
        }
        ListTradeMark.Add(name);
        return Task.FromResult<IActionResult>(Ok());
    }


    [HttpGet("list")]
    
    public List<string> ListMark()
    {
        return ListTradeMark;
    }
}
//ListTradeMark.Contains(newName)
    


