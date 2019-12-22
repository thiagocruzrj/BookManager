﻿using BookManager.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManager.Author.Domain.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        void Add(Category category);
        void Update(Category category);
    }
}