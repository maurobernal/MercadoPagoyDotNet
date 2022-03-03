using MPIntegracion.Models;
namespace MPIntegracion.Services;
public class ProductosServices
{
    public List<ProductoDTO> GetListProductos()
    {
        List<ProductoDTO> Listado=new();

        Listado.Add(new ProductoDTO{ ID=Guid.NewGuid(),imagen="/img/logo.png",Titulo="Pack 10mbps",Precio=50,Descripcion="Velocidad simétrica, IP dinámico"  });
        Listado.Add(new ProductoDTO{ ID=Guid.NewGuid(),imagen="/img/logo.png",Titulo="Pack 20mbps",Precio=100,Descripcion="Velocidad simétrica, IP dinámico"  });
        Listado.Add(new ProductoDTO{ ID=Guid.NewGuid(),imagen="/img/logo.png",Titulo="Pack 30mbps",Precio=150,Descripcion="Velocidad simétrica, fijo"  });
        Listado.Add(new ProductoDTO{ ID=Guid.NewGuid(),imagen="/img/logo.png",Titulo="Pack 40mbps",Precio=200,Descripcion="Velocidad simétrica, fijo"  });
        Listado.Add(new ProductoDTO{ ID=Guid.NewGuid(),imagen="/img/logo.png",Titulo="Pack 50mbps",Precio=250,Descripcion="Velocidad simétrica, fijo"  });

        return Listado;
    }
}
