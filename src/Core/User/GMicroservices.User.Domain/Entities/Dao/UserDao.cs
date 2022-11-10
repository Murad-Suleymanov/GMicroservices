namespace GMicroservices.User.Domain.Entities.Dao
{
    public class UserDao
    {
        public int Id { get; set; }
        public int UserTypeId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
