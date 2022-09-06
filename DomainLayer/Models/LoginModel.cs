namespace DomainLayer.Models
{
    public class LoginModel
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    public class CambioPasswordModel
    {
        public string? Email { get; set; }
        public string? TempPassword { get; set; }
        public string? NewPassword1 { get; set; }
        public string? NewPassword2 { get; set; }
    }    
}
