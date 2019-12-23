using BookManager.Catalog.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Catalog.Application.Services
{
    public interface ICategoryAppService : IDisposable
    {
        Task<IEnumerable<CategoryViewModel>> GetCategories();

        Task Add(CategoryViewModel categoryViewModel);
        Task Update(CategoryViewModel categoryViewModel);
        Task Delete(CategoryViewModel categoryViewModel);
        Task<int> SaveChanges();
    }
}
