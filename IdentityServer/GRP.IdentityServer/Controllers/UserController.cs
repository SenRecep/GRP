using AutoMapper;

using GRP.IdentityServer.Dtos;
using GRP.IdentityServer.Models;
using GRP.Shared.Core.ExtensionMethods;
using GRP.Shared.Core.Response;
using GRP.Shared.Core.StringInfo;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using static Duende.IdentityServer.IdentityServerConstants;

namespace GRP.IdentityServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(LocalApi.PolicyName)]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public UserController(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = userManager.Users.ToList();
            var mapping = mapper.Map<IEnumerable<ApplicationUserDto>>(users);
            return Response<IEnumerable<ApplicationUserDto>>.Success(mapping).CreateResponseInstance();
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            ApplicationUser user = mapper.Map<ApplicationUser>(model);

            IdentityResult result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return GetResult(result, "SignUp");


            IdentityResult roleResult = await userManager.AddToRoleAsync(user, RoleInfo.User);

            if (!roleResult.Succeeded)
                return GetResult(roleResult, "SignUp_AddRole");

            return Response<NoContent>.Success(statusCode: StatusCodes.Status201Created).CreateResponseInstance();
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            Claim userClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

            if (userClaim.IsNull()) return Response<NoContent>.Fail(
                 statusCode: StatusCodes.Status400BadRequest,
                 isShow: true,
                 path: "api/User/GetUser",
                 errors: "Kullanici girisi dogrulanamadi"
                 ).CreateResponseInstance();

            ApplicationUser user = await userManager.FindByIdAsync(userClaim.Value);

            if (user.IsNull()) return Response<NoContent>.Fail(
                 statusCode: StatusCodes.Status400BadRequest,
                 isShow: true,
                 path: "api/User/GetUser",
                 errors: "Gecerli bir kullanici bulunamadi"
                 ).CreateResponseInstance();

            var dto = mapper.Map<ApplicationUserDto>(user);

            return Response<ApplicationUserDto>.Success(
                 data: dto,
                 statusCode: StatusCodes.Status200OK
                  ).CreateResponseInstance();
        }

        private IActionResult GetResult(IdentityResult result, string action = "UpdateProfile")
        {
            return Response<NoContent>.Fail(
                      statusCode: StatusCodes.Status400BadRequest,
                      isShow: true,
                      path: $"api/User/{action}",
                      errors: result.Errors.Select(x => x.Description).ToArray()
                      ).CreateResponseInstance();
        }
    }
}
