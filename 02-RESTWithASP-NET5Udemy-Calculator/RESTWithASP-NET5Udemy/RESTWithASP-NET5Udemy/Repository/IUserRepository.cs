using RESTWithASP_NET5Udemy.Data.VO;
using RESTWithASP_NET5Udemy.Model;

namespace RESTWithASP_NET5Udemy.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
        User RefreshUserInfo(User user);
    }
}
