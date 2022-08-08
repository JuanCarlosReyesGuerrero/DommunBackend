using System.Security.Claims;

namespace DommunBackend.DomainLayer.DTOs
{
    public class RolePermissionDto
    {
        public string? RoleId { get; set; }
        public string? Name { get; set; }
        public string? ClaimType { get; set; }
        public IEnumerable<Claim>? Claim { get; set; }
    }
}
