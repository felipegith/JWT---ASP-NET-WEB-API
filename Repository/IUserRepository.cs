using Jesstw.Model;

namespace Jesstw.Repository
{
    public interface IUserRepository
    {
        User Create (User user);
        User ValidateCredentials(UserVO user);

        User ValidateCredentialsRefreshToken(string Email);
    }
}