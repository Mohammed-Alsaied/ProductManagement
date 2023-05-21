
namespace AuthPermission.Entity
{
    public class Permission : BaseEntity
    {
        public string Action { get; set; }
        public string Resource { get; set; }
        public string RoleId { get; set; }
        public IdentityRole Role { get; set; }
    }
}
