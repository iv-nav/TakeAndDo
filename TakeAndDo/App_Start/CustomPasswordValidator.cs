using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// navrockiy
namespace TakeAndDo.App_Start
{
    public class CustomPasswordValidator : PasswordValidator
    {
        public CustomPasswordValidator(int length)
        {
            RequiredLength = length;
            RequireNonLetterOrDigit = false;
            RequireDigit = true;
            RequireLowercase = true;
            RequireUppercase = true;
        }

    }
}