using System;
using Microsoft.AspNetCore.Identity;

namespace MTGCore.Authentication.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        // Using a custom identity will make it easier to add additional properties/claims in the future
    }
}