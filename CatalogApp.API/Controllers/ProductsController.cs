using CatalogApp.Application.DTOs;
using CatalogApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogApp.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
    {
        var products = await _productService.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDTO>> Get(int id)
    {
        var product = await _productService.GetById(id);

        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProductDTO productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _productService.Add(productDto);

        return new CreatedAtRouteResult("GetProduct",
        new { id = productDto.Id }, productDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDto)
    {
        if (id != productDto.Id)
        {
            return BadRequest();
        }

        await _productService.Update(productDto);
        return Ok(productDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ProductDTO>> Delete(int id)
    {
        var productDto = await _productService.GetById(id);
        if (productDto == null)
        {
            return NotFound();
        }
        await _productService.Remove(id);
        return Ok(productDto);
    }
}
