using DataLayer.Class;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IdentityCalls
{
    public class SignInManager : SignInManager<User, Guid>
    {
        public SignInManager(UserManager<User, Guid> userManager, IAuthenticationManager authenticationManager)
        : base(userManager, authenticationManager) { }

        public void SignOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
