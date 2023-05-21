public class PermissionUnitOfWork : BaseUnitOfWork<Permission>, IPermissionUnitOfWork
{
    public PermissionUnitOfWork(IBaseRepository<Permission> repsitory) : base(repsitory)
    {
    }
}