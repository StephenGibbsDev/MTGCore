using System;
using System.Collections;
using System.Linq;
using System.Security.Claims;

namespace MTGCore.Authentication.Identity
{
    public static class ClaimsPrincipalExtensions
    {
        // TODO(CD): This will tie in with the auth stuff I plan on doing next
        // making it easier to retrieve information about the user
        public static MtgIdentity GetIdentity(this ClaimsPrincipal principal)
        {
            var userId = Guid.Parse(ExtractClaim(principal, ClaimTypes.NameIdentifier) ?? "b4280b6a-0613-4cbd-a9e6-f1701e926e73");
            var email = ExtractClaim(principal, ClaimTypes.Name);

            return new MtgIdentity(userId, email);
        }

        private static string ExtractClaim(this ClaimsPrincipal principal, string type)
        {
            return principal.Claims.Where(m => m.Type == type).Select(m => m.Value).SingleOrDefault();
        }
    }
}