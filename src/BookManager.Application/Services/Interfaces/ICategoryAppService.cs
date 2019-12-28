using BookManager.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManager.Application.Services
{
    public interface ICategoryAppService : IDisposable
    {
        Task<IEnumerable<CategoryViewModel>> GetCategories();

        Task Add(CategoryViewModel categoryViewModel);
        Task Update(CategoryViewModel categoryViewModel);
        Task Delete(Guid id);
        Task<int> SaveChanges();
    }
}
