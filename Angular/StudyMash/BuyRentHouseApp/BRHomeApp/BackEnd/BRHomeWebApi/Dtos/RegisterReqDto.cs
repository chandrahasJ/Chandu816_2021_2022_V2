namespace BRHomeWebApi.Dtos
{
    public class RegisterReqDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
    }
}