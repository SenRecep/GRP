using Microsoft.AspNetCore.Identity;

namespace GRP.IdentityServer.Services
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email) => new IdentityError()
        {
            Code = "DuplicateEmail",
            Description = $"{email} adresi kullanılmaktadır."
        };
        public override IdentityError DuplicateUserName(string userName) => new IdentityError()
        {
            Code = "DuplicateUserName",
            Description = $"{userName} kullanıcı adı kullanılmaktadır."
        };
    }
}
