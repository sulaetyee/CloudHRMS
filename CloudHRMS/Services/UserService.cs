
using System.Security.Policy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace CloudHRMS.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        public async Task<string> CreateUserAsync(string userName, string password, string email)
        {
            var user = CreateUser();
            user.UserName = userName;
            user.Email = email;
            user.NormalizedUserName = userName;

            var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    var roleName = "Employee";
                    var roleExist = await _roleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                   
                        await _roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                    await _userManager.AddToRoleAsync(user, roleName);
                    return user.Id;
                }
            throw new Exception("User creation failed! Please check user details and try again.");

        }
                
        

        public async Task<IList<string>> GetRolesByUserIdAsync(string userId)
        {
           var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                throw new InvalidOperationException($"User with ID '{user.Id}' not found!");
            }
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }
        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
    }
}
