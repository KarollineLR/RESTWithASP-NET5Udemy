using RESTWithASP_NET5Udemy.Data.VO;

namespace RESTWithASP_NET5Udemy.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);
        TokenVO ValidateCredentials(TokenVO token);
        bool RevokeToken(string username);
    }
}
