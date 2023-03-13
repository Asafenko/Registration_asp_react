using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Registration_asp_react.Controllers;

[ApiController]
[Route("[controller]")]
public class TradeMarkController : ControllerBase
{
    private static readonly List<string> ListTradeMark = new(); 
    // Count 1.000.000
    // Ближе к 1.000.000 = O(n)
    // Ближе к 1 трлн = O(n^2)
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
    // n = 1.000.000 (кол-во тов. знаков), k - среднее кол символов в название
    public Task<IActionResult> Register(string name)
    {
        var registrant = RemoveStringReader(name);

        bool IsDuplicated(string newTrademark) // O(k), 10 op., O(k), k = ~10
        {
            // n = newTrademark.Length (~10)
            var normalizedTrademark = RemoveStringReader(newTrademark);// O(k), 10 op.
            // O(k), 10 op
            return string.Equals(normalizedTrademark, registrant, StringComparison.OrdinalIgnoreCase);
        }

        if (ListTradeMark.Exists(IsDuplicated))// k=10 // n раз выполняет k операций O(n * k)
        {
            return Task.FromResult<IActionResult>(BadRequest(new { message = "Error" }));
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

    


