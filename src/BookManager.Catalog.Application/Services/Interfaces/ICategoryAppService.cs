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

        void Add(CategoryViewModel categoryViewModel);
        void Update(CategoryViewModel categoryViewModel);
        void Delete(CategoryViewModel categoryViewModel);
    }
}
