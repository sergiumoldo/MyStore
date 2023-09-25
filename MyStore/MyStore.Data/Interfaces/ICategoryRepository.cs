﻿using MyStore.NewFolder;

namespace MyStore.MyStore.Data.Interfaces
{
    public interface ICategoryRepository
    {
        Category Add(Category category);
        int Delete(Category category);
        IEnumerable<Category> GetAll(int page);
        IQueryable<Category> GetAll();
        IQueryable<Category> GetAll(int page, string? text);
        Category? GetCategoryById(int id);
        Category Update(Category category);
    }
}