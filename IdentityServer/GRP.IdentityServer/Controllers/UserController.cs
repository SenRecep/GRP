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
using Microsoft.Extensions.Logging;

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
        private readonly ILogger<UserController> logger;

        public UserController(UserManager<ApplicationUser> userManager, IMapper mapper,ILogger<UserController> logger )
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = userManager.Users.ToList();
            ICollection<ApplicationUserDto> data=new List<ApplicationUserDto>();
            foreach (var user in users)
            {
                var map = mapper.Map<ApplicationUserDto>(user);
                map.Roles = await userManager.GetRolesAsync(user);
                data.Add(map);
            }
            return Response<IEnumerable<ApplicationUserDto>>.Success(data).CreateResponseInstance();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            ApplicationUser user = mapper.Map<ApplicationUser>(model);

            IdentityResult result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return GetResult(result, "SignUp");


            IdentityResult roleResult = await userManager.AddToRolesAsync(user, model.Roles);

            if (!roleResult.Succeeded)
                return GetResult(roleResult, "SignUp_AddRole");

            return Response<NoContent>.Success(statusCode: StatusCodes.Status201Created).CreateResponseInstance();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ApplicationUserDto dto)
        {
            var updateModel = mapper.Map<ApplicationUser>(dto);
            var user = await userManager.FindByIdAsync(updateModel.Id);
            if (user.IsNull()) return Response<NoContent>.Fail(
              statusCode: StatusCodes.Status400BadRequest,
              isShow: true,
              path: "api/role/put",
              errors: "Gecerli bir kullanici bulunamadi"
              ).CreateResponseInstance();

            if (!user.Email.Equals(updateModel.Email))
            {
                var emailResponse = await userManager.SetEmailAsync(user, updateModel.Email);
                if (!emailResponse.Succeeded) return GetResult(emailResponse, "UpdateEmail");
            }

            if (!user.PhoneNumber.Equals(updateModel.PhoneNumber))
            {
                var res = await userManager.SetPhoneNumberAsync(user, updateModel.PhoneNumber);
                if (!res.Succeeded) return GetResult(res, "UpdatePhoneNumber");
            }

            if (!user.UserName.Equals(updateModel.UserName))
            {
                var res = await userManager.SetUserNameAsync(user, updateModel.UserName);
                if (!res.Succeeded) return GetResult(res, "UpdateUserName");
            }


            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            var passwordRes = await userManager.ResetPasswordAsync(user, token, dto.Password);

            if (!passwordRes.Succeeded) return GetResult(passwordRes, "UpdatePassword");

            user.FirstName = updateModel.FirstName;
            user.LastName = updateModel.LastName;
            user.IdentityNumber = updateModel.IdentityNumber;
            user.Address = updateModel.Address;
            var updateResult = await userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
                return GetResult(updateResult, "UpdateUser");

            var userRoles = await userManager.GetRolesAsync(user);
            logger.LogInformation($"Update Dto Roles: ${dto.Roles.IsNotNull()} {dto.Roles?.Count()}");
            logger.LogInformation($"User Roles: ${userRoles.IsNotNull()} {userRoles?.Count()}");
            var deleteRoles = userRoles?.Where(x => !dto.Roles.Contains(x));
            var addRoles = dto.Roles?.Where(x => !userRoles.Contains(x));
            await userManager.RemoveFromRolesAsync(user, deleteRoles);
            await userManager.AddToRolesAsync(user, addRoles);
            return Response<NoContent>.Success().CreateResponseInstance();
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
            dto.Roles = await userManager.GetRolesAsync(user);

            return Response<ApplicationUserDto>.Success(
                 data: dto,
                 statusCode: StatusCodes.Status200OK
                  ).CreateResponseInstance();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id.ToString());

            if (user.IsNull()) return Response<NoContent>.Fail(
                 statusCode: StatusCodes.Status400BadRequest,
                 isShow: true,
                 path: "api/User/GetUser",
                 errors: "Gecerli bir kullanici bulunamadi"
                 ).CreateResponseInstance();

            var dto = mapper.Map<ApplicationUserDto>(user);
            dto.Roles = await userManager.GetRolesAsync(user);

            return Response<ApplicationUserDto>.Success(
                 data: dto,
                 statusCode: StatusCodes.Status200OK
                  ).CreateResponseInstance();
        }

        private IActionResult GetResult(IdentityResult result, string action = "UpdateProfile")
        {

            var response= Response<NoContent>.Fail(
                      statusCode: StatusCodes.Status400BadRequest,
                      isShow: true,
                      path: $"api/User/{action}",
                      errors: result.Errors.Select(x => x.Description).ToArray()
                      );
            logger.LogResponse(response);
            return response.CreateResponseInstance();
        }
    }
}
