namespace Common
{
    using System.Linq.Expressions;

    public interface IBaseUnitOfWork<T>
        where T : BaseEntity
    {
        Task<List<T>> ReadAsync();
        Task<T> ReadByIdAsync(Guid entityId);
        Task<List<T>> ReadByExpressionAsync(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(Guid id);
    }
}