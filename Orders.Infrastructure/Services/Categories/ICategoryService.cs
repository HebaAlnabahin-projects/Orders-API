using Orders.Core.Dto;
using Orders.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Infrastructure.Services.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAll(string searchKey);
        Task<CategoryViewModel> Get(int id);
        Task<int> Create(CreateCategoryDto dto);
        Task<int> Update(UpdateCategoryDto dto);
        Task<int> Delete(int id);
    }
}
