using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Services.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services;

public class CategoryService : ICategoryService
{
    private ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<IReadOnlyList<CategoryDTO>> GetCategoriesAsync()
    {
        var categoriesEntity = await _categoryRepository.GetCategoriesAsync();
        var categoriesDTO = _mapper.Map<IReadOnlyList<CategoryDTO>>(categoriesEntity);
        return categoriesDTO;
    }

    public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
    {
        var categoryEntity = await _categoryRepository.GetByIdAsync(id);
        var categoryDTO = _mapper.Map<CategoryDTO>(categoryEntity);
        return categoryDTO;
    }

    public async Task AddAsync(CategoryDTO category)
    {

        var categoryEntitie = _mapper.Map<Category>(category);
        await _categoryRepository.CreateAsync(categoryEntitie);
    }

    public async Task UpdateAsync(CategoryDTO category)
    {
        var categoryEntitie = _mapper.Map<Category>(category);
        await _categoryRepository.UpdateAsync(categoryEntitie);
    }

    public async Task RemoveAsync(int id)
    {
        var categoryEntity = await _categoryRepository.GetByIdAsync(id);
        await _categoryRepository.RemoveAsync(categoryEntity!);
    }
}
