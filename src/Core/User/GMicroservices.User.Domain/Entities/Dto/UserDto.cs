using GMicroservices.User.Domain.Enums;

namespace GMicroservices.User.Domain.Entities.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public UserTypes UserTypeId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
