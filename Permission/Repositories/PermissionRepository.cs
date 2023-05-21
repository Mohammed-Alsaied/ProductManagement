public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
{
    public PermissionRepository(DbContext dbContext) : base(dbContext)
    {
    }


}