using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Filters
{
    public class RequireClaimAttribute : TypeFilterAttribute
    {
        public RequireClaimAttribute(string ClaimType, string ClaimValue) : base(typeof(RequireClaimFilter))
        {
            Arguments = new object[] { ClaimType, ClaimValue };
        }
    }
}