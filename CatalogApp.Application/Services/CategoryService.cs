using AutoMapper;
using CatalogApp.Application.DTOs;
using CatalogApp.Application.Interfaces;
using CatalogApp.Domain.Entities;
using CatalogApp.Domain.Interfaces;

namespace CatalogApp.Application.Services;

public class CategoryService : ICategoryService
{
    private ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        try
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesAsync();
            var categoriasDto = _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
            return categoriasDto;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CategoryDTO> GetById(int? id)
    {
        var categoryEntity = await _categoryRepository.GetByIdAsync(id);
        return _mapper.Map<CategoryDTO>(categoryEntity);
    }

    public async Task Add(CategoryDTO categoryDto)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.CreateAsync(categoryEntity);
    }

    public async Task Update(CategoryDTO categoryDto)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.UpdateAsync(categoryEntity);
    }

    public async Task Remove(int? id)
    {
        var categoryEntity = _categoryRepository.GetByIdAsync(id).Result;
        await _categoryRepository.RemoveAsync(categoryEntity);
    }
}
