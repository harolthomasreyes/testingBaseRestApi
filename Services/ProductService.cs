namespace Services;

using Domain;
using Repository.Interface;

public class ProductService
{
    private readonly IGenericRepository<Product> _repository;
    private List<Product> products = new List<Product>
    {
        new Product(1, "Laptop", 1200.00m),
        new Product(2, "Smartphone", 800.00m),
        new Product(3, "Tablet", 400.00m),
        new Product(4, "Monitor", 250.00m),
        new Product(5, "Keyboard", 50.00m),
        new Product(6, "Mouse", 30.00m),
        new Product(7, "Printer", 150.00m),
        new Product(8, "Webcam", 70.00m),
        new Product(9, "Headphones", 90.00m),
        new Product(10, "Speaker", 110.00m)
    };
    public ProductService(IGenericRepository<Product> repository)
    {
        _repository = repository;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return products;
    }

    public Product GetProductById(int id)
    {
        return products.Find(id => id == id);
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void UpdateProduct(Product product)
    {
       products = products.Select(p =>
        p.Id == product.Id
            ? new Product(product.Id, product.Name, product.Price)
            : p
        ).ToList();
    }

    public void DeleteProduct(int id)
    {
        products.RemoveAll(p => p.Id == id);
    }
}