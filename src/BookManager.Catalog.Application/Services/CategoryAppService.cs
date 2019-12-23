using AutoMapper;
using BookManager.Catalog.Application.ViewModels;
using BookManager.Catalog.Data;
using BookManager.Catalog.Domain;
using BookManager.Catalog.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Catalog.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        protected readonly CatalogContext Db;

        public CategoryAppService(ICategoryRepository categoryRepository, IMapper mapper, CatalogContext db)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            Db = db;
        }
        public async Task Add(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            _categoryRepository.Add(category);

            await SaveChanges();
        }

        public async Task Delete(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            _categoryRepository.Delete(category);

            await SaveChanges();
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            return _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryRepository.GetCategories());
        }

        public async Task Update(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            _categoryRepository.Update(category);

            await SaveChanges();
        }
        public void Dispose()
        {
            Db?.Dispose();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
    }
}
