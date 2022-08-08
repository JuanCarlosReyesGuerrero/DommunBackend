namespace DommunBackend.DomainLayer.DTOs
{
    public class RoleClaimsDto
    {
        public int Id { get; set; }
        public string? RoleId { get; set; }
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
        public bool Selected { get; set; }
    }
}
