using System;

namespace MTGCore.Authentication.Identity
{
    public class MtgIdentity
    {
        public Guid Id { get; }
        public string Email { get; }

        public MtgIdentity(Guid id, string email)
        {
            Id = id;
            Email = email;
        }
    }
}