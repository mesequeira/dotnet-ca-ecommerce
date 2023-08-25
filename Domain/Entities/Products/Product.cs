namespace Domain.Entities.Products;

public class Product
{
    public long Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public virtual Category Category { get; set; }

}
