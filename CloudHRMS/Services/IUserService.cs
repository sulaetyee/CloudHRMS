namespace CloudHRMS.Services
{
    public interface IUserService
    {
        //asynchronous programming approach
        Task<string> CreateUserAsync(string userName,string password, string email);
        Task<IList<string>> GetRolesByUserIdAsync(string userId);
    }
}
