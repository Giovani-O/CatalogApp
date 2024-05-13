using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.Application.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o nome da categoria")]
    [MinLength(3)]
    [MaxLength(100)]
    public string Name { get; set; } = String.Empty;

    [Required(ErrorMessage = "Informe o nome da imagem")]
    [MinLength(5)]
    [MaxLength(250)]
    public string ImageUrl { get; set; } = String.Empty;
}
