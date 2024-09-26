using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize,
 Route("api/[controller]")]
public class FrutasController : ControllerBase
{
    private static List<string> frutas = new List<string> { "Maçã", "Banana", "Laranja" };

    [HttpGet]
    public IActionResult GetFrutas()
    {
        return Ok(frutas);
    }

    [HttpPost]
    public IActionResult AddFruta([FromBody] string fruta)
    {
        frutas.Add(fruta);
        return Ok(frutas);
    }
}
