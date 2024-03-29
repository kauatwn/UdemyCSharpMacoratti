﻿using CatalogDb.API.Context;
using CatalogDb.API.Entities;
using CatalogDb.API.Pagination;

namespace CatalogDb.API.Repositories
{
    public class CategoryRepository(AppDbContext context) : Repository<Category>(context), ICategoryRepository
    {
        public async Task<PagedList<Category>> GetPagedCategoriesAsync(CategoryQueryParameters categoryQuery)
        {
            var orderedCategories = GetAll().OrderBy(p => p.Id);
            var pagedCategoryList = await PagedList<Category>.ToPagedList(orderedCategories, categoryQuery.PageNumber, categoryQuery.PageSize);
            if (pagedCategoryList.Count == 0)
            {
                throw new Exception("List of categories not found");
            }
            return pagedCategoryList;
        }

        public async Task<PagedList<Category>> GetCategoriesFilteredByNameAsync(CategoryNameFilter filter)
        {
            var categories = GetAll();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                categories = categories.Where(c => c.Name.Contains(filter.Name));
            }
            var filteredCategories = await PagedList<Category>.ToPagedList(categories, filter.PageNumber, filter.PageSize);
            return filteredCategories;
        }
    }
}
