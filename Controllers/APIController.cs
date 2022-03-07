using Microsoft.AspNetCore.Mvc;
namespace MPIntegracion.API;

[ApiController]
[Route("[controller]")]
public class APIController: ControllerBase{
[HttpGet("GetPago")] public string GetPago()
{
    return "Pago devuelto";
}

[HttpPost("GuardarPago")] public string GuardarPago(string ID)
{
    return ID;
}

}