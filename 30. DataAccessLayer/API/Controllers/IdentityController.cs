//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using MTS.BL.Infra.APILibrary;
//using static MTS.Core.GlobalLibrary.Constants;

//namespace MTS.DataAcces.AccountAPI.Controllers
//{
//    [Route(APIControllers.IDENTITY)]
//    [ApiController]
//    public class IdentityController : ControllerBase
//    {
//        private readonly IConfiguration _configuration;
//        private readonly UserManager<EFUserAccount> _userManager;
//        private readonly SignInManager<EFUserAccount> _signInManager;

//        public IdentityController(
//            IConfiguration configuration,
//            UserManager<EFUserAccount> userManager,
//            SignInManager<EFUserAccount> signInManager)
//        {
//            _configuration = configuration;
//            _userManager = userManager;
//            _signInManager = signInManager;
//        }

//        [AllowAnonymous]
//        [Route(IdentityControllerEndpoints.LOG_IN)]
//        [HttpPut]
//        public async Task<ActionResult<UserToken>> LogIn([FromBody] CredentialHolder credentials)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(new string[] { "Invalid credentials" });

//            List<string> responses = new List<string>();

//            EFUserAccount userAccount = await _userManager.FindByEmailAsync(credentials.Email);

//            if (userAccount == null)
//            {
//                responses.Add("No user exists with this email and password");
//            }

//            if (!userAccount.EmailConfirmed)
//            {
//                responses.Add("Email not yet confirmed by user");
//            }

//            if (!userAccount.IsAdmitted)
//            {
//                responses.Add("Email not yet confirmed by admin");
//            }

//            if (responses.Count > 0)
//                return Unauthorized(responses.ToArray());

//            var result = await _signInManager.PasswordSignInAsync(credentials.Email, credentials.Password, isPersistent: credentials.RememberMe, lockoutOnFailure: true);
//            if (!result.Succeeded)
//            {
//                if (result.IsLockedOut)
//                {
//                    Unauthorized($"You are locked out for some time");
//                }

//                if (result.IsNotAllowed)
//                {
//                    responses.Add($"You are not allowed to login for some time");
//                }

//                if (responses.Count == 0)
//                {
//                    responses.Add("Wrong password");
//                }

//                responses.Add($"Login attempts remaining: {_signInManager.Options.Lockout.MaxFailedAccessAttempts - userAccount.AccessFailedCount}");
//                return Unauthorized(responses.ToArray());
//            }

//            return Accepted("Login succesfull", BuildToken(userAccount).Value);
//        }

//        [Route(IdentityControllerEndpoints.LOG_OUT)]
//        [HttpHead]
//        public async Task<ActionResult> LogOut()
//        {
//            await _signInManager.SignOutAsync();

//            return Ok();
//        }

//        private UserToken BuildToken(EFUserAccount userAccount)
//        {
//            var claims = new[]
//            {
//                new Claim(JwtRegisteredClaimNames.UniqueName, $"{userAccount.Email.GetHashCode()}{DateTime.UtcNow}{userAccount.PasswordHash.GetHashCode()}"),
//                new Claim(ClaimTypes.Name, userAccount.FirstName ?? "No Name"),
//                new Claim(ClaimTypes.Role, Enum.GetName(typeof(AccessLevel), userAccount.AccessLevel)),
//                new Claim(ClaimTypes.Email, userAccount.Email),
//                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
//            };

//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["ValidateIssuerSigningKey:Key"]));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            // Expiration time
//            var expiration = DateTime.UtcNow.AddMinutes(10);

//            JwtSecurityToken token = new JwtSecurityToken(
//               issuer: null,
//               audience: null,
//               claims: claims,
//               expires: expiration,
//               signingCredentials: creds);

//            return new UserToken(
//                userId: userAccount.Id,
//                loginProvider: "MTS-Security",
//                userName: userAccount.UserName,
//                expiration: expiration,
//                jwtSecurityToken: new JwtSecurityTokenHandler().WriteToken(token));
//        }
//    }
//}