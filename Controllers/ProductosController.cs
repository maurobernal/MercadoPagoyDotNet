using Microsoft.AspNetCore.Mvc;
using MPIntegracion.Services;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
namespace MPIntegracion.Controllers;
using MPIntegracion.Models;

public class ProductosController : Controller
{
    public async Task<IActionResult> MostrarProductos()
    {
      var ListProductos= new ProductosServices().GetListProductos();
      foreach(ProductoDTO p in ListProductos)
      {
          p.URL=await GenerarPreferencia(p);
      }
      ViewData["Productos"]=ListProductos;
        return View();
    }

    private async Task<string> GenerarPreferencia(ProductoDTO producto)
    {
        MercadoPagoConfig.AccessToken = "TEST-3462044254849055-082315-bfc04228bd5e2d225b29d800c26fd4d4__LC_LD__-116392764";
        PreferenceClient Cliente_Preferencias = new();
        PreferenceRequest Request = new();
        List<PreferenceItemRequest> ListadoItems = new();
        Request.Items = ListadoItems;
        ListadoItems.Add(new PreferenceItemRequest
        {
            UnitPrice = decimal.Parse(producto.Precio.ToString()),
            Title = producto.Titulo,
            Id =producto.ID.ToString(),
            Description = producto.Descripcion,
            CurrencyId = "AR",
            Quantity=1

        });
        Request.BackUrls = new PreferenceBackUrlsRequest()
        {
            Failure = "Fallo",
            Success = "Exitosos",
            Pending = "Pendiente"
        };

        Request.NotificationUrl = "webhook";

        Request.Payer = new PreferencePayerRequest()
        {
            Name = "Nombre",
            Email="test@test.com"
        };

        var res = await Cliente_Preferencias.CreateAsync(Request);

        return res.InitPoint;
    }

}