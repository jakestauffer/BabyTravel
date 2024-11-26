using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Utilities
{
    public static class ClaimsExtensions
    {
        public static string? GetUserEmail(this ClaimsPrincipal claimsPrinciples) =>
            claimsPrinciples.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
    }
}
