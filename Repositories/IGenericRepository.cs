using System.Linq.Expressions;

namespace UniversityManagementSystem_Final.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null,
            Expression<Func<T, object>>[] includes = null);

        Task<T> GetByIdAsync(int id);
        Task AddAsync(T obj);
        //Task<List<T>> GetWithFilterAsync(Expression<Func<T, bool>> expression = null);
        Task Update(T obj);
        void Delete(int id);
        Task Delete2(T obj);
        Task SaveAsync();
    }
}
