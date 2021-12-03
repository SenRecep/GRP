using GRP.IdentityServer.Dtos;
using GRP.Shared.Core.ExtensionMethods;
using GRP.Shared.Core.Response;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static Duende.IdentityServer.IdentityServerConstants;

namespace GRP.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(LocalApi.PolicyName)]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return 
                Response<IEnumerable<string>>
                .Success(roles.Select(x=>x.Name))
                .CreateResponseInstance();
        }

    }
}
