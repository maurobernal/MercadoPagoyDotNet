namespace MPIntegracion.Models
{
    public class ProductoDTO
    {
        public Guid ID { get; set; }
        public string? Titulo { get; init; }=string.Empty;
        public string? Descripcion { get; set; }=string.Empty;
        public string? URL { get; set; }="";
        public string? imagen { get; set; }="";
        public double Precio {get;set;}

    }
}