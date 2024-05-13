using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; } = String.Empty;

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; set; } = String.Empty;

        [Required(ErrorMessage = "Informe o preço")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [MaxLength(250)]
        public string ImageUrl { get; set; } = String.Empty;

        [Required(ErrorMessage = "O estoque é obrigatório")]
        [Range(1, 9999)]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Informe a data do cadastro")]
        public DateTime RegisterDate { get; set; }
        public int CategoryId { get; set; }
    }
}
