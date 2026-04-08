using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Filters
{
    public class RequireClaimFilter : IAuthorizationFilter
    {
        private readonly string _claimType;
        private readonly string _claimValue;

        public RequireClaimFilter(string ClaimType, string ClaimValue)
        {
            _claimType = ClaimType;
            _claimValue = ClaimValue;
        }

        public void OnAuthorization(AuthorizationFilterContext _context)
        {
            if (!_context.HttpContext.User.Identity.IsAuthenticated)
            {
                _context.Result = new UnauthorizedResult();
                return;
            }

            var hasClaim = _context.HttpContext.User.Claims.Where(c => c.Type == _claimType && c.Value == _claimValue);

            if (!hasClaim.Any())
            {
                _context.Result = new ForbidResult();
            }
        }
    }
}