using CatalogApp.Domain.Validation;

namespace CatalogApp.Domain.Entities;

public class Product : Entity
{
    public Product(
        string name, string description, decimal price, string imageUrl, int stock, DateTime registerDate
    )
    {
        ValidateDomain(name, description, price, imageUrl, stock, registerDate);
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public string ImageUrl { get; private set; }
    public int Stock { get; private set; }
    public DateTime RegisterDate { get; private set; }

    public void Update(
        string name, string description, decimal price, string imageUrl, int stock, DateTime registerDate, int categoryd
    )
    {
        ValidateDomain(name, description, price, imageUrl, stock, registerDate);
        CategoryId = categoryd;
    }

    private void ValidateDomain(
        string name, string description, decimal price, string imageUrl, int stock, DateTime registerDate
    )
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido");

        DomainExceptionValidation.When(name.Length < 3, "O nome deve ter no mínimo 3 caracteres");

        DomainExceptionValidation.When(string.IsNullOrEmpty(description), "A descrição é obrigatória");

        DomainExceptionValidation.When(description.Length < 5, "A descrição deve ter no mínimo 5 caracteres");

        DomainExceptionValidation.When(price < 0.0m, "Preço inválido");

        DomainExceptionValidation.When(imageUrl?.Length > 250, "A URL da imagem não pode exceder 250 caracteres");

        DomainExceptionValidation.When(stock < 0, "Estoque inválido");

        Name = name;
        Description = description;
        Price = price;
        ImageUrl = imageUrl ?? "";
        Stock = stock;
        RegisterDate = registerDate;
    }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
