using Microsoft.AspNetCore.Identity;

namespace HotelSearchAPI.Engine
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
