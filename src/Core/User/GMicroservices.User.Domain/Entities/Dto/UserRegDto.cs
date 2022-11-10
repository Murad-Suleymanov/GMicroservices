using GMicroservices.User.Domain.Enums;

namespace GMicroservices.User.Domain.Entities.Dto
{
    public class UserRegDto
    {
        public UserTypes UserTypeId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
