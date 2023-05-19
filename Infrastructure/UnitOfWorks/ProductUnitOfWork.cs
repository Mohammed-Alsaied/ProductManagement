public class ProductUnitOfWork : BaseUnitOfWork<Product>, IProductUnitOfWork
{
    public ProductUnitOfWork(IBaseRepository<Product> repsitory) : base(repsitory)
    {
    }
}