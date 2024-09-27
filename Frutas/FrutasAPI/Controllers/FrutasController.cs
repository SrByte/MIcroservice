using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize,
 Route("api/[controller]")]
public class FrutasController : ControllerBase
{
    private static List<string> frutas = new List<string> { "Maçã", "Banana", "Laranja" };

    [HttpGet]
public async Task<IActionResult> GetFrutas()
{
    // Simulando uma operação assíncrona
    await Task.Delay(100);
    return Ok(frutas);
}
   [HttpPost]
public async Task<IActionResult> AddFruta([FromBody] string fruta)
{
    // Simulando uma operação assíncrona
    await Task.Delay(100);
    frutas.Add(fruta);
    return Ok(frutas);
}

}
