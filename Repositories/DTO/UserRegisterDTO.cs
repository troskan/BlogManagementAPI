namespace BlogManagementAPI.Repositories.DTO
{
    public class UserRegisterDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; } = 1;
        public DateTime DateRegistered { get; set; } = DateTime.Now;
    }
}
