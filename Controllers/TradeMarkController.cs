using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Registration_asp_react.Controllers;

[ApiController]
[Route("[controller]")]
public class TradeMarkController : ControllerBase
{
    private static readonly List<string> _listTradeMark=new()
    {
        "asaf","asaf2","asaf3"
    };
    private readonly ILogger<TradeMarkController> _logger;

    public TradeMarkController(ILogger<TradeMarkController> logger)
    {
        _logger = logger;
    }
    
    private static string RemoveStringReader(string input)
    {
        var s = new StringBuilder(input.Length); // (input.Length);
        using (var reader = new StringReader(input))
        {
            var i = 0;
            char c;
            for (; i < input.Length; i++)
            {
                c = (char)reader.Read();
                if (!char.IsWhiteSpace(c))
                {
                    s.Append(c);
                }
            }
        }

        return s.ToString();
    }

    [HttpGet("registration")]
    public async Task<IActionResult> Registration(string name)
    {
        var newName = RemoveStringReader(name);
        if (_listTradeMark.Contains(newName))
        {
            return BadRequest(new { message = "Error" });
        }
        _listTradeMark.Add(newName);
        return Ok();
    }


    [HttpGet("list")]
    
    public List<string> ListMark()
    {
        return _listTradeMark;
    }
}
        
    


