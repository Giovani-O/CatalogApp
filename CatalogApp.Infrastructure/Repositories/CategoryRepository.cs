using CatalogApp.Domain.Entities;
using CatalogApp.Domain.Interfaces;
using CatalogApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogApp.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private ApplicationDbContext _categoryContext;
    public CategoryRepository(ApplicationDbContext context)
    {
        _categoryContext = context;
    }

    public async Task<Category> CreateAsync(Category category)
    {
        _categoryContext.Add(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> GetByIdAsync(int? id)
    {
        return await _categoryContext.Categories.FindAsync(id);
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        try
        {
            var categorias = await _categoryContext.Categories.ToListAsync();
            return categorias;
        }
        catch (Exception)
        {
            throw;
        }

    }

    public async Task<Category> RemoveAsync(Category category)
    {
        _categoryContext.Remove(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        _categoryContext.Update(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }
}
