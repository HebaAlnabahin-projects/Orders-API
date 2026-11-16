using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Orders.API.Data;
using Orders.Core.Dto;
using Orders.Core.ViewModels;
using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;

namespace Orders.Infrastructure.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly OrdersDbContext _db;
        private readonly IMapper _mapper;

        public CategoryService(OrdersDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<CategoryViewModel>> GetAll(string searchKey)
        {
            var categories = _db.Categories.Where(x => x.Name.Contains(searchKey) || string.IsNullOrEmpty(searchKey))
                .Select(x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    MealCount = _db.Meals.Count(x => x.CategoryId == x.Id)
                }).ToList();
            return categories;
        } 

        public async Task<int> Delete(int id)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == id); 
            if(category == null)
            {
                throw new Exception("Category not found");
            }
            category.IsDelete = true;
            _db.Categories.Update(category);
            _db.SaveChanges();
            return category.Id;
        }

        public async Task<CategoryViewModel> Get(int id)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            var categoryVm = _mapper.Map<CategoryViewModel>(category);
            categoryVm.MealCount = _db.Meals.Count(x => x.CategoryId == category.Id);
            return categoryVm;
        }

        public async Task<int> Create([FromQuery]CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            _db.Categories.Add(category);
            _db.SaveChanges();
            return category.Id;
        }

        public async Task<int> Update(UpdateCategoryDto dto)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == dto.Id);
            if(category == null)
            {
                throw new Exception("Category not found");
            }
            var updatedCategory = _mapper.Map(dto, category);
            _db.Update(category);
            _db.SaveChanges();
            return category.Id;
        }

    }
}
