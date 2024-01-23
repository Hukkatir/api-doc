namespace BackendApi.Contracts.Role
{
    public class GetRoleResponse
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public string Descrip { get; set; } = null!;
        public int CreatedBy { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
