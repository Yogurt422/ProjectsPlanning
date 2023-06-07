using Microsoft.AspNetCore.Identity;

namespace ProjectsPlanning.Chernetsov.Entities
{
    public class User : IdentityUser<int>
    {
        public bool IsDeleted { get; set; }



    }
}
