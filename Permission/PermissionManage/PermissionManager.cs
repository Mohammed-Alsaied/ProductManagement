
namespace AuthPermission.PermissionManage
{
    public class PermissionManager
    {
        private readonly IBaseUnitOfWork<Permission> _unitOfWork;

        public PermissionManager(IBaseUnitOfWork<Permission> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Permission>> GetPermissionByRole(IdentityRole role, string resource) => await _unitOfWork.ReadByExpressionAsync(p => p.Role == role && p.Resource == resource);
        public async Task CreateAsync(Permission permission)
        {
            _unitOfWork.CreateAsync(permission);
        }
    }
}
