

namespace AJN.Gorman.Domain
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AuthContext
        : IdentityDbContext<IdentityUser>
    {
    }
}
