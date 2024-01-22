namespace BackendApi.Contracts.Role
{
    public class CreateRoleRequest
    {
        public string RoleName { get; set; } = null!;
        public string Descrip { get; set; } = null!;
        public int CreatedBy { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
