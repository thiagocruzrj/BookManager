using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManager.Domain.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
