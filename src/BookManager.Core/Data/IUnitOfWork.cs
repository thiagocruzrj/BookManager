using System.Threading.Tasks;

namespace BookManager.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
