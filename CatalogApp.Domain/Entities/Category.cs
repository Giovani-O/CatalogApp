using CatalogApp.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.Domain.Entities;

// sealed: This class can't be inherited
public sealed class Category : Entity
{
    public Category(string name, string imageUrl)
    {
        ValidateDomain(name, imageUrl);
    }

    public Category(int id, string name, string imageUrl)
    {
        DomainExceptionValidation.When(id < 0, "valor de Id é inválido");
        Id = id;
        ValidateDomain(name, imageUrl);
    }

    public string Name { get; private set; }
    public string ImageUrl { get; private set;}
    public ICollection<Product> Products { get; set; }

    /// <summary>
    /// Validate the business logic of the model
    /// </summary>
    /// <param name="name"></param>
    /// <param name="imageUrl"></param>
    private void ValidateDomain(string name, string imageUrl)
    {
        DomainExceptionValidation
            .When(string.IsNullOrEmpty(name), "O nome é obrigatório");

        DomainExceptionValidation
            .When(string.IsNullOrEmpty(imageUrl), "A imagem é obrigatória");

        DomainExceptionValidation
            .When(name.Length < 3, "O nome deve ter no mínimo 3 caracteres");

        DomainExceptionValidation
            .When(imageUrl.Length < 5, "A URL da imagem deve ter no mínimo 5 caracteres");

        Name = name;
        ImageUrl = imageUrl;
    }
}
