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

    public async Task<IReadOnlyList<CategoryDTO>> GetCategoriesAsync(CancellationToken cancellationToken)
    {
        var categoriesEntity = await _categoryRepository.GetCategoriesAsync(cancellationToken);
        var categoriesDTO = _mapper.Map<IReadOnlyList<CategoryDTO>>(categoriesEntity);
        return categoriesDTO;
    }

    public async Task<CategoryDTO> GetCategoryByIdAsync(int id, CancellationToken cancellationToken)
    {
        var categoryEntity = await _categoryRepository.GetByIdAsync(id, cancellationToken);
        var categoryDTO = _mapper.Map<CategoryDTO>(categoryEntity);
        return categoryDTO;
    }

    public async Task AddAsync(CategoryDTO category, CancellationToken cancellationToken)
    {

        var categoryEntitie = _mapper.Map<Category>(category);
        await _categoryRepository.CreateAsync(categoryEntitie, cancellationToken);
    }

    public async Task UpdateAsync(CategoryDTO category, CancellationToken cancellationToken)
    {
        var categoryEntitie = _mapper.Map<Category>(category);
        await _categoryRepository.UpdateAsync(categoryEntitie, cancellationToken);
    }


    public async Task RemoveAsync(int id, CancellationToken cancellationToken)
    {
        var categoryEntity = await _categoryRepository.GetByIdAsync(id, cancellationToken);
        await _categoryRepository.RemoveAsync(categoryEntity!, cancellationToken);
    }
}
